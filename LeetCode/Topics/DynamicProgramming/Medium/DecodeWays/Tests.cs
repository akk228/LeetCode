using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace LeetCode.Topics.DynamicProgramming.Medium.DecodeWays;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { "27", 1 }, // "AB" (1,2) or "L" (12)
            new object[] { "12", 2 }, // "AB" (1,2) or "L" (12)
            new object[] { "226", 3 }, // "BZ" (2,26), "VF" (22,6), or "BBF" (2,2,6)
            new object[] { "0", 0 }, // No valid decoding
            new object[] { "06", 0 }, // No valid decoding
            new object[] { "10", 1 }, // "J" (10)
            new object[] { "11106", 2 }, // "AAJF" (1,1,10,6) or "KJF" (11,10,6)
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new MySolution()
        // Add other implementations of ISolution here
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestNumDecodings(string s, int expected)
    {
        foreach (var solution in _solutions)
        {
            int result = solution.NumDecodings(s);
            Assert.Equal(expected, result);
        }
    }
}
