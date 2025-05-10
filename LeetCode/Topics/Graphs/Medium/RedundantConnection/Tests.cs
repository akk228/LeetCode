using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace LeetCode.Topics.Graphs.Medium.RedundantConnection;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] {  (int[][]) [[1,2],[1,3],[2,3]], new[] { 2, 3 } },
            new object[] { new int[][] { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }, new[] { 4, 1 }, new[] { 1, 5 } }, new[] { 4, 1 } },
            new object[] { new int[][] { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }, new[] { 4, 5 }, new[] { 5, 1 }, new[] { 1, 6 } }, new[] { 5, 1 } },
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new MySolution()
        // Add other implementations of ISolution here
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestFindRedundantConnection(int[][] edges, int[] expected)
    {
        foreach (var solution in _solutions)
        {
            int[] result = solution.FindRedundantConnection(edges);
            Assert.Equal(expected, result);
        }
    }
}
