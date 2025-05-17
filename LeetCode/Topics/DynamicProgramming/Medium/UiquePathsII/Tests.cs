using System.Collections.Generic;
using Xunit;

namespace LeetCode.Topics.DynamicProgramming.Medium.UiquePathsII;

public class Tests
{
    public static IEnumerable<object[]> Data
    {
        get
        {
            yield return [ new[] { new[] { 0, 0 }, new[] { 0, 0 } }, 2 ];
            yield return [ new[] { new[] { 0, 1 }, new[] { 0, 0 } }, 1 ];
            yield return [ new[] { new[] { 0, 1 }, new[] { 1, 0 } }, 0 ];
            yield return [ new[] { new[] { 1, 0 }, new[] { 0, 0 } }, 0 ];
            yield return [ new[] { new[] { 0, 0 }, new[] { 0, 1 } }, 0 ];
            yield return [ new[] { new[] { 0, 0, 0 }, new[] { 0, 1, 0 }, new[] { 0, 0, 0 } }, 2 ];
            yield return [ new[] { new[] { 0 } }, 1 ];
            yield return [ new[] { new[] { 1 } }, 0 ];
        }
    }

    private readonly ISolution solution = new MySolution();

    [Theory]
    [MemberData(nameof(Data))]
    public void UniquePathsWithObstacles_ReturnsExpected(int[][] grid, int expected)
    {
        var result = solution.UniquePathsWithObstacles(grid);
        Assert.Equal(expected, result);
    }
}
