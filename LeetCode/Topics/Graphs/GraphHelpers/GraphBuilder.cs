using System.Collections.Immutable;

namespace LeetCode.Topics.Graphs.GraphHelpers;

public class GraphBuilder
{
    public List<int>[] BuildUndirectedUnweightedGraph(int[][] edges, int V)
    {
        var graph = new List<int>[V];
        
        foreach (var edge in edges)
        {
            if (edge.Length != 2)
            {
                throw new Exception("Edge of can contain only two vertices");
            }

            try
            {
                if (graph[edge[0]] is null) graph[edge[0]] = new List<int>();
                if (graph[edge[1]] is null) graph[edge[1]] = new List<int>();
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new Exception(e.Message + "\n" + 
                                    "Edge contains the vertex that is not a part of this graph");
            }
        }
        
        return graph;
    }
}