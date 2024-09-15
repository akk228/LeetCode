namespace LeetCode.Topics.Graphs.Easy.DfsOfConnectedGraph;

//{ Driver Code Starts
//Initial Template for C#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    public int[] dfsOfGraph(int V, List<int>[] adj)
    {
        //Your code here
        var visitedNodes = new bool[V];
        var traversal = new List<int>();
        
        Dfs(0, adj, visitedNodes, traversal);
        
        return traversal.ToArray();
    }
    
    private void Dfs(int currentNode, List<int>[] graph, bool[] visitedNodes, List<int> traversal)
    {
        if(visitedNodes[currentNode]) return;
        
        visitedNodes[currentNode] = true;
        traversal.Add(currentNode);
        
        foreach(var linkedNode in graph[currentNode]){
            Dfs(linkedNode, graph, visitedNodes, traversal);
        }
    }
}