namespace Studying.LeetCode.Topics.Graphs.Hard.LongestCycleInGraph;

public class Solution : ISolution
{
    public int LongestCycle(int[] edges)
    {
        var visited = new int[edges.Length];
        var longestCycle = -1;

        for (var v = 0; v < edges.Length; v++)
        {
            if (visited[v] == 0)
            {
                longestCycle = Math.Max(longestCycle, DFS(v, edges, visited, 1));
            }
        }

        return longestCycle;
    }

    private int DFS(int v, int[] edges, int[] visited, int count)
    {
        if (visited[v] == -1)
        {
            return -1;
        }

        if (visited[v] > 0)
        {
            return count - visited[v];
        }

        visited[v] = count;

        var longestCycle = edges[v] != -1 ? DFS(edges[v], edges, visited, count + 1) : -1;
        visited[v] = -1;

        return longestCycle;
    }
}
