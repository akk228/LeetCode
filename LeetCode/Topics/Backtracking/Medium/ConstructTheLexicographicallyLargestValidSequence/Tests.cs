using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace LeetCode.Topics.Backtracking.Medium.ConstructTheLexicographicallyLargestValidSequence;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { 3, new int[] { 3, 1, 2, 3, 2 } },
            new object[] { 4, new int[] { 4, 2, 3, 2, 4, 3, 1} },
            new object[] { 5, new int[] { 5, 3, 1, 4, 3, 5, 2, 4, 2 } }
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new Solution(),
        new MySolution()
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestConstructDistancedSequence(int n, int[] expected)
    {
        foreach (var solution in _solutions)
        {
            int[] result = solution.ConstructDistancedSequence(n);
            Assert.Equal(expected, result);
        }
    }
}
