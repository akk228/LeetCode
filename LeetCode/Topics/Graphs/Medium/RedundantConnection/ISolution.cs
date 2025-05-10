using System;

namespace LeetCode.Topics.Graphs.Medium.RedundantConnection;

/// <summary>
/// 684. Redundant Connection
/// </summary>
public interface ISolution
{
    /// <summary>
    /// Finds the redundant connection in a graph represented by edges.
    /// </summary>
    /// <param name="edges">The edges of the graph.</param>
    /// <returns>The redundant connection as an array of two integers.</returns>
    // int[] FindRedundantDirectedConnection(int[][] edges);

    /// <summary>
    /// Finds the redundant connection in a directed graph represented by edges.
    /// </summary>
    /// <param name="edges">The edges of the directed graph.</param>
    /// <returns>The redundant connection as an array of two integers.</returns>
    int[] FindRedundantConnection(int[][] edges);
}
