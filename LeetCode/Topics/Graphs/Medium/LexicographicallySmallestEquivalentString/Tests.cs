using System.Collections.Generic;
using Xunit;

namespace LeetCode.Topics.Graphs.Medium.LexicographicallySmallestEquivalentString;

public class Tests
{
    public static IEnumerable<object[]> TestData
    {
        get
        {
            // Example 1: Simple equivalence
            yield return new object[] { "parker", "morris", "parser", "makkek" };
            // Example 2: All letters equivalent
            yield return new object[] { "abc", "bca", "abcd", "aaad" };
            // Example 3: No equivalence
            yield return new object[] { "abc", "def", "xyz", "xyz" };
            // Example 4: Overlapping equivalence
            yield return new object[] { "leetcode", "programs", "sourcecode", "aauaaaaada" };
            // Example 5: Single letter
            yield return new object[] { "a", "b", "a", "a" };
        }
    }

    private readonly IEnumerable<ISolution> _solutions = new ISolution[] { new MySolution() };

    [Theory]
    [MemberData(nameof(TestData))]
    public void ReturnsExpectedResult(string s1, string s2, string baseStr, string expected)
    {
        foreach (var sol in _solutions)
        {
            var actual = sol.SmallestEquivalentString(s1, s2, baseStr);
            Assert.Equal(expected, actual);
        }
    }
}
