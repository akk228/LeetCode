namespace LeetCode.Topics.Graphs.Medium;

/// <summary>
/// 3310. Remove Methods From Project
/// </summary>
public class Solution {
    public IList<int> RemainingMethods(int n, int k, int[][] invocations) {
        var methodGraph = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            methodGraph[i] = new List<int>();
        }
        
        foreach(var invocation in invocations){
            methodGraph[invocation[0]].Add(invocation[1]);
        }
        
        var bugyMethods = new HashSet<int>();
        
        DfsFromOneNode(k, methodGraph, bugyMethods);
        
        var visitedNodes = new bool[n];
        
        for(var node = 0; node < n; node++){
            if(bugyMethods.Contains(node)){
                continue;
            }
            
            if(DfsFromOneNode(node, methodGraph, bugyMethods, visitedNodes)){
                return Enumerable.Range(0, n).ToList();
            }
        }
        
        return Enumerable.Range(0, n).Where(num => !bugyMethods.Contains(num)).ToList();
    }
    
    private bool DfsFromOneNode(int currentNode, List<int>[] graph, HashSet<int> untouchableNodes, bool[] visitedNodes)
    {
        if(visitedNodes[currentNode]) return false;
        if(untouchableNodes.Contains(currentNode)) return true;
        
        visitedNodes[currentNode] = true;
        
        foreach(var linkedNode in graph[currentNode]){
            if(DfsFromOneNode(linkedNode, graph, untouchableNodes, visitedNodes)){
                return true;
            };
        }
        
        return false;
    }
    
    private void DfsFromOneNode(int currentNode, List<int>[] graph, HashSet<int> visitedNodes)
    {
        if(visitedNodes.Contains(currentNode)) return;
        
        visitedNodes.Add(currentNode);
        
        foreach(var linkedNode in graph[currentNode]){
            DfsFromOneNode(linkedNode, graph, visitedNodes);
        }
    }
}