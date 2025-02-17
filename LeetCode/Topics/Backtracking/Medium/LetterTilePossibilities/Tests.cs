using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace LeetCode.Topics.Backtracking.Medium.LetterTilePossibilities;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { "AAB", 8 },
            new object[] { "AAABBC", 188 },
            new object[] { "V", 1 }
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new Solution()
        // Add other implementations of ISolution here
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestNumTilePossibilities(string tiles, int expected)
    {
        foreach (var solution in _solutions)
        {
            int result = solution.NumTilePossibilities(tiles);
            Assert.Equal(expected, result);
        }
    }
}
