using System.Collections.Generic;
using Xunit;

namespace LeetCode.Topics.Matrix.Medium.DetectCyclesIn2DGrid;

public class Tests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>()
    {
        new object[] { new char[][] { new[] { 'a', 'a', 'a', 'a' }, new[] { 'a', 'b', 'b', 'a' }, new[] { 'a', 'b', 'a', 'a' }, new[] { 'a', 'a', 'a', 'a' } }, true },
        new object[] { new char[][] { new[] { 'a', 'b', 'b' }, new[] { 'b', 'z', 'b' }, new[] { 'b', 'b', 'a' } }, false },
        new object[] { new char[][] { new[] { 'a', 'a', 'a', 'a' }, new[] { 'a', 'b', 'b', 'a' }, new[] { 'a', 'b', 'b', 'a' }, new[] { 'a', 'a', 'a', 'a' } }, true },
        new object[] { new char[][] { new[] { 'a', 'b', 'c' }, new[] { 'd', 'e', 'f' }, new[] { 'g', 'h', 'i' } }, false },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void DetectsCycleCorrectly(char[][] grid, bool expectedContainsCycle)
    {
        var solution = new MySolution();
        var actualContainsCycle = solution.ContainsCycle(grid);
        Assert.Equal(expectedContainsCycle, actualContainsCycle);
    }
}