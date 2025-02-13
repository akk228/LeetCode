using System.Diagnostics.CodeAnalysis;

namespace Studying.LeetCode.Topics.Graphs.Hard.LongestCycleInGraph;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { new int[] { 3, 3, 4, 2, 3 }, 3 },
            new object[] { new int[] { 2, -1, 3, 1 }, -1 },
            new object[] { new int[] { 1, 2, 0 }, 3 }
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new Solution()
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestLongestCycle(int[] edges, int expected)
    {
        foreach (var solution in _solutions)
        {
            int result = solution.LongestCycle(edges);
            Assert.Equal(expected, result);
        }
    }
}
