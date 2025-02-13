namespace Studying.LeetCode.Topics.Graphs.Hard.LongestCycleInGraph;

public class Solution : ISolution
{
    public int LongestCycle(int[] edges) {
        var visited = new bool[edges.Length];
        var edgeCounts = new int[edges.Length];
        var longestCycle = -1;

        for (var v = 0; v < edges.Length; v++)
        {
            if (!visited[v])
            {
                longestCycle = Math.Max(longestCycle, DFS(v, edges, visited, edgeCounts));
            }
        }

        return longestCycle;
    }

    private int DFS(int v, int[] edges, bool[] visited, int[] edgeCounts, int count = 1)
    {
        if (visited[v] && edgeCounts[v] == 0)
        {
            return -1;
        }

        if (edgeCounts[v] > 0)
        {
            return count - edgeCounts[v];
        }

        visited[v] = true;
        edgeCounts[v] = count;

        var longestCycle = edges[v] != -1 ? DFS(edges[v], edges, visited, edgeCounts, count + 1) : -1;
        edgeCounts[v] = 0;

        return longestCycle;
    }
}
