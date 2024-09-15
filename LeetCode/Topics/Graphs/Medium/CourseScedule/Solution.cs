namespace LeetCode.Topics.Graphs.Medium.CourseScedule;
/// <summary>
/// 207. Course Schedule
/// </summary>
/// <remarks>
///     Beats 98.26% in runtime
///     Beats 99.53% in memory
/// </remarks>
public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var courseGraph = new List<int>[numCourses];

        foreach(var coursePair in prerequisites){
            if(courseGraph[coursePair[1]] is null)
                courseGraph[coursePair[1]] = new List<int>();
            courseGraph[coursePair[1]].Add(coursePair[0]);
        }

        return !isCycle(numCourses, courseGraph);
    }

    bool isCycle(int V, List<int>[] graph){
        var visitedNodes = new bool[V];
        var visitedCurrentTraversal = new bool[V];

        for(int node = 0; node < V; ++node){
            if(DfsCatchCycle(node, graph, visitedNodes, visitedCurrentTraversal))
                return true;
        }

        return false;
    }

    bool DfsCatchCycle(int currentNode, List<int>[] graph, bool[] visitedNodes, bool[] visitedInCurrentTraversal)
    {
        if(visitedInCurrentTraversal[currentNode]) return true;
        if(visitedNodes[currentNode] || graph[currentNode] is null) return false;

        visitedNodes[currentNode] = true;
        visitedInCurrentTraversal[currentNode] = true;

        foreach(var linkedNode in graph[currentNode])
            if(DfsCatchCycle(linkedNode, graph, visitedNodes, visitedInCurrentTraversal))
                return true;
        
        visitedInCurrentTraversal[currentNode] = false;
        return false;
    }
}