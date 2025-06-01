using System.Collections.Generic;
using Xunit;

namespace LeetCode.Topics.Matrix.Medium.SnakesAndLeaders;

public class Tests
{
    public static IEnumerable<object[]> TestData
    {
        get
        {
            // Example 1: Standard board
            yield return new object[]
            {
                new int[][]
                {
                    new[] {-1, -1, -1, -1, -1, -1},
                    new[] {-1, -1, -1, -1, -1, -1},
                    new[] {-1, -1, -1, -1, -1, -1},
                    new[] {-1, 35, -1, -1, 13, -1},
                    new[] {-1, -1, -1, -1, -1, -1},
                    new[] {-1, 15, -1, -1, -1, -1}
                },
                4
            };
            // Example 2: No snakes or ladders
            yield return new object[]
            {
                new int[][]
                {
                    new[] {-1, -1, -1},
                    new[] {-1, -1, -1},
                    new[] {-1, -1, -1}
                },
                2
            };
            yield return new object[]
            {
                new int[][]
                {
                    new[] {-1, 4},
                    new[] {-1, 3}
                },
                1
            };
            // Example 4: Single cell
            yield return new object[]
            {
                new int[][]
                {
                    new[] {-1}
                },
                0
            };
            yield return new object[]
            {
                (int[][])
                [
                    [-1,-1,2,-1],
                    [14,2,12,3],
                    [4,9,1,11],
                    [-1,2,1,16]],
                1
            };
            yield return new object[]
            {
                (int[][])
                [
                    [-1,-1,-1,-1,48,5,-1],
                    [12,29,13,9,-1,2,32],
                    [-1,-1,21,7,-1,12,49],
                    [42,37,21,40,-1,22,12],
                    [42,-1,2,-1,-1,-1,6],
                    [39,-1,35,-1,-1,39,-1],
                    [-1,36,-1,-1,-1,-1,5]
                ],
                3
            };
        }
    }

    private readonly IEnumerable<ISolution> _solutions = new ISolution[] {
        new GraphSolution(),
        // new DfsSolution(),
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void ReturnsExpectedResult(int[][] board, int expected)
    {
        foreach (var sol in _solutions)
        {
            var actual = sol.SnakesAndLadders(board);
            Assert.Equal(expected, actual);
        }
    }
}
