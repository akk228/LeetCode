using System;

namespace LeetCode.Topics.DynamicProgramming.Medium.UiquePathsII;

/// <summary>
/// 63. Unique Paths II
/// </summary>
public interface ISolution
{
    /// <summary>
    /// Returns the number of unique paths from the top-left corner to the bottom-right corner of a grid,
    /// avoiding obstacles.
    /// </summary>
    /// <param name="obstacleGrid">A 2D grid representing the obstacle layout.</param>
    /// <returns>The number of unique paths.</returns>
    int UniquePathsWithObstacles(int[][] obstacleGrid);
}
