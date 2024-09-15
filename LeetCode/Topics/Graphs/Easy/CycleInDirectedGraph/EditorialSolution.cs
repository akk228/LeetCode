namespace LeetCode.Topics.Graphs.Easy.CycleInDirectedGraph;

public class EditorialSolution : ICycleInDirectedGraphSolution
{
    private bool isCyclicUtil(int v, bool[] visited, bool[] recStack, List<int>[] adj)
    {
        if (!visited[v])
        {
            visited[v] = true;
            recStack[v] = true;

            foreach(var linkedNode in adj[v])
            {
                if (!visited[linkedNode] && isCyclicUtil(linkedNode, visited, recStack, adj))
                    return true;
                if (recStack[linkedNode])
                    return true;
            }
        }

        recStack[v] = false;
        return false;
    }

    public bool isCyclic(int V, List<int>[] adj)
    {
        bool[] visited = new bool[V];
        bool[] recStack = new bool[V];

        for (int i = 0; i < V; i++)
        {
            if (isCyclicUtil(i, visited, recStack, adj))
                return true;
        }

        return false;
    }
}