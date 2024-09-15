using LeetCode.Topics.Graphs.Easy.CycleInDirectedGraph;

class Solution : ICycleInDirectedGraphSolution
{
    public bool isCyclic(int V, List<int>[] adj)
    {
        //Your code here
        var visitedNodes = new bool[V];
        var visitedCurrentTraversal = new bool[V];
        
        for(int node = 0; node < V; ++node){
            if(isDfsCyclic(adj, visitedNodes, node, visitedCurrentTraversal))
                return true;
        }
        
        return false;
    }
    
    private bool isDfsCyclic(List<int>[] graph, bool[] visitedNodes, int currentNode, bool[] visitedCurrentTraversal)
    {
        // If we have encountered same node in the current traversal, it means the loop is closed
        if (visitedCurrentTraversal[currentNode]) return true;
        // If we haven't encountered that node in current traversal, but we traversed it already, it measn that it didn't result
        // in detecting a loop, so doesn't make sense to go further 
        if (visitedNodes[currentNode]) return false;

        visitedNodes[currentNode] = true;
        visitedCurrentTraversal[currentNode] = true;

        foreach (var linkedNode in graph[currentNode])
        {
            if (isDfsCyclic(graph, visitedNodes, linkedNode, visitedCurrentTraversal))
                return true;
        }

        // this assignment does a clean up, in case there are several paths that
        // do not form a loop but go through the same node
        visitedCurrentTraversal[currentNode] = false;
        return false;
    }
}