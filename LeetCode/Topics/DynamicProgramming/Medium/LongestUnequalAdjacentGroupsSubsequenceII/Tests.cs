using System.Collections.Generic;
using Xunit;

namespace LeetCode.Topics.DynamicProgramming.Medium.LongestUnequalAdjacentGroupsSubsequenceII;

public class Tests
{
    public static IEnumerable<object[]> Data
    {
        get
        {
            // Basic test: alternating groups, hamming distance 1
            yield return [new[] { "abc", "abd", "acc", "adc" }, new[] { 1, 2, 1, 2 }, 2];
            // Single word
            yield return [new[] { "a" }, new[] { 1 }, 1];
            // No valid subsequence (all groups same)
            yield return [new[] { "abc", "def", "ghi" }, new[] { 1, 1, 1 }, 1];
            // All words can be chained
            yield return [new[] { "abc", "abd", "abe" }, new[] { 1, 1, 2 }, 2];
            yield return [new[] { "bab", "dab", "cab" }, new[] { 1, 2, 2 }, 2];
            yield return [new[] { "a","b","c","d" }, new[] { 1, 2, 3, 4 }, 4];
            // Empty input
            // yield return [  new string[0], new int[0], 0 ];
        }
    }

    private readonly IList<ISolution> _solution = new List<ISolution>
    {
        new MySolution()
        // new Solution()
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void GetWordsInLongestSubsequence_ReturnsExpectedLength(string[] words, int[] groups, int expectedLength)
    {
        foreach (var solution in _solution)
        {
            var result = solution.GetWordsInLongestSubsequence(words, groups);
            Assert.Equal(expectedLength, result.Count);
        }
    }
}
