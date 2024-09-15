namespace LeetCode.Topics.Graphs.Easy.CycleInDirectedGraph;

public interface ICycleInDirectedGraphSolution
{
    /// <summary>
    /// Method that detects cycle in a graph
    /// </summary>
    /// <param name="V">number of vertices</param>
    /// <param name="graph">Graph in the from of adjacency list</param>
    /// <returns>true - in case there is a cycle, otherwise - false</returns>
    bool isCyclic(int V, List<int>[] graph);
}