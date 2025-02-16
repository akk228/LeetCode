namespace Studying.LeetCode.Topics.Graphs.Hard.ShortestCycleInUndirectedGraph;

public class Solution : ISolution
{
    public int FindShortestCycle(int n, int[][] edges) {
        var graph = GetGraphFromEdges(n, edges);
        var visited = new bool[n];
        var distance = new int[n];
        var shortestCycle = Int32.MaxValue;

        for (var v = 0; v < n; v++)
        {
            if (visited[v])
            {
                continue;
            }

            shortestCycle = Math.Min(shortestCycle, DFS(v, graph, distance, visited));
        }

        return shortestCycle == int.MaxValue ? -1 : shortestCycle;
    }

    private List<int>[] GetGraphFromEdges(int v, int[][] edges)
    {
        var graph = new List<int>[v];

        foreach (var edge in edges)
        {
            if (graph[edge[0]] is null)
            {
                graph[edge[0]] = new List<int>();
            }

            graph[edge[0]].Add(edge[1]);

            if (graph[edge[1]] is null)
            {
                graph[edge[1]] = new List<int>();
            }

            graph[edge[1]].Add(edge[0]);
        }

        foreach (var list in graph)
        {
            if (list is not null)
            {
                list.Sort();
            }
        }

        return graph;
    }

    private int DFS(int v, List<int>[] graph, int[] distance, bool[] visited, int parent = -1, int count = 1)
    {
        if (visited[v] && graph[v] is not null)
        {
            // distance[v] = 1;
            return count > distance[v] ? count - distance[v] : Int32.MaxValue;
        }

        if (graph[v] is null)
        {
            return Int32.MaxValue;
        }

        var shortestCycle = Int32.MaxValue;
        distance[v] = count;
        visited[v] = true;

        foreach (var child in graph[v])
        {
            if (child != parent)
            {
                shortestCycle = Math.Min(shortestCycle, DFS(child, graph, distance, visited, v, Math.Min(distance[v] + 1, count + 1)));
                if (parent != -1) distance[v] = Math.Min(distance[v], distance[child] + 1);
            }
        }

        return shortestCycle;
    }
}
