namespace LeetCode.Topics.Graphs.Easy.BfsOfConnectedGraph;

public class Solution
{
    public List<int> bfsOfGraph(int V, List<int>[] adj)
    {
        //Your code here
        var visitedNodes = new bool[V];
        var traversal = new List<int>();
        var nodeQueue = new Queue<int>();
        
        nodeQueue.Enqueue(0);
        visitedNodes[0] = true;
        traversal.Add(0);
        
        while(nodeQueue.Count > 0)
        {
            var currentNode = nodeQueue.Dequeue();

            foreach (var linkedNode in adj[currentNode].Where(linkedNode => !visitedNodes[linkedNode]))
            {
                visitedNodes[linkedNode] = true;
                traversal.Add(linkedNode);
                nodeQueue.Enqueue(linkedNode);
            }
        }
        
        return traversal;
    }
}