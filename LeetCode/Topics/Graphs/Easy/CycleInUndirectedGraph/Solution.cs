namespace LeetCode.Topics.Graphs.Easy.CycleInUndirectedGraph;

class Solution
{
    //Complete this function
    //Function to detect cycle in an undirected graph.
    public bool isCycle(int V, List<int>[] adj)
    {
        //Code here
        var visitedNodes = new bool[V];
            
        for(int node = 0; node < V; node++)
        {
            if (visitedNodes[node]) continue;
            if(DfsDetectedCycle( adj, visitedNodes, node)) return true;
        }
            
        return false;
    }
        
    private bool DfsDetectedCycle(List<int>[] graph, bool[] visitedNodes, int currentNode, int parentNode = -1)
    {
        if(parentNode != currentNode && visitedNodes[currentNode])
            return true;
                
        visitedNodes[currentNode] = true;
            
        foreach(var linkedNode in graph[currentNode]){
            if(linkedNode == parentNode) continue;
            if (DfsDetectedCycle(graph, visitedNodes, linkedNode, currentNode))
                return true;
        }

        return false;
    }
}