using System;

namespace LeetCode.Topics.Graphs.Medium.RedundantConnection;

/// <summary>
/// Shitty solution. Works correct though.
/// </summary>
public class MySolution : ISolution
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        var graph = BuildGraphFromEdges(edges);
        var nodesInCycle = new List<int>();
        var visited = new HashSet<int>();

        foreach (var node in graph.Keys)
        {
            if (DetectCycle(node, -1, graph, visited, nodesInCycle))
            {
                break;
            }
        }

        var edgesInCycle = new List<(int a, int b)>();
        var current = 0;

        while (current < nodesInCycle.Count)
        {
            edgesInCycle.Add(
                (
                    Math.Min(nodesInCycle[current], nodesInCycle[current + 1]),
                    Math.Max(nodesInCycle[current], nodesInCycle[current + 1])
                )
            );
            current++;
            if (nodesInCycle[0] == nodesInCycle[current])
            {
                break;
            }
        }

        var lastIndex = 0;

        for (var i = 0; i < edges.Length; i++)
        {
            foreach (var edge in edgesInCycle)
            {
                if ((edge.a == edges[i][0] && edge.b == edges[i][1]) ||
                    (edge.a == edges[i][1] && edge.b == edges[i][0]))
                {
                    lastIndex = i;
                    break;
                }
            }
        }

        return edges[lastIndex];
    }

    private Dictionary<int, List<int>> BuildGraphFromEdges(int[][] edges)
    {
        var graph = new Dictionary<int, List<int>>();

        foreach (var edge in edges)
        {
            if (!graph.ContainsKey(edge[0]))
            {
                graph.Add(edge[0], new List<int>());
            }

            graph[edge[0]].Add(edge[1]);

            if (!graph.ContainsKey(edge[1]))
            {
                graph.Add(edge[1], new List<int>());
            }

            graph[edge[1]].Add(edge[0]);
        }

        return graph;
    }

    private bool DetectCycle(int currentNode, int parentNode, Dictionary<int, List<int>> graph, HashSet<int> visited, List<int> nodesInCycle)
    {
        var isCycle = false;

        if (visited.Contains(currentNode))
        {
            isCycle = currentNode != parentNode;

            if (isCycle)
            {
                nodesInCycle.Add(currentNode);
            }

            return isCycle;
        }

        visited.Add(currentNode);

        foreach (var node in graph[currentNode])
        {
            if (node != parentNode && DetectCycle(node, currentNode, graph, visited, nodesInCycle))
            {
                nodesInCycle.Add(currentNode);
                return true;
            }
        }

        return false;
    }
}
