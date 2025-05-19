using System;

namespace LeetCode.Algos.Graphs;

public class Dijkstra
{
    // Returns shortest distances from src to all other vertices
    public int[] dijkstra(int V, int[,] edges, int src) {
        // Code here
        var graph = BuildUndirectedGraphFromEdges(V, edges);
        var vertexData = new VertexData[V];
        var nodeQueue = new PriorityQueue<int, int>();
        
        nodeQueue.Enqueue(src, 0);
        int vertex, weight;
        
        while (nodeQueue.TryDequeue(out vertex, out weight))
        {
            if (vertexData[vertex].Visited)
            {
                continue;
            }

            var parent = vertexData[vertex].ParentVertex;

            vertexData[vertex].Visited = true;
            vertexData[vertex].Distance = weight + vertexData[parent].Distance;

            foreach (var nextVertex in graph[vertex])
            {
                vertexData[nextVertex.Next].ParentVertex = vertex;
                nodeQueue.Enqueue(nextVertex.Next, nextVertex.Weight);
            }
        }
        
        return vertexData.Select(x => x.Distance).ToArray();
    }
    
    private struct VertexData
    {
        public VertexData()
        {
            Distance = Int32.MaxValue;
        }
        
        public int Distance;
        public bool Visited;
        public int ParentVertex;
    }
    
    private List<(int Next, int Weight)>[] BuildUndirectedGraphFromEdges(int V,int[,] edges)
    {
        var graph = new List<(int Next, int Weight)>[V];
        
        for(var vertex = 0; vertex < V; vertex++)
        {
            graph[vertex] = new List<(int Next, int Weight)>();
        }
        
        var edgeCount = edges.GetLength(0);
        
        for (var i = 0; i < edgeCount; i++)
        {
            var vert1 = edges[i, 0];
            var vert2 = edges[i, 1];
            var weight = edges[i, 2];

            graph[vert1].Add((vert2, weight));
            graph[vert2].Add((vert1, weight));
        }
        
        return graph;
    }
}
