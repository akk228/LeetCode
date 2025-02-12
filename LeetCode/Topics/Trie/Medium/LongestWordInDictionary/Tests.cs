using System.Diagnostics.CodeAnalysis;

namespace Studying.LeetCode.Topics.Trie.Medium.LongestWordInDictionary;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { new string[] { "w", "wo", "wor", "worl", "world" }, "world" },
            new object[] { new string[] { "a", "banana", "app", "appl", "ap", "apply", "apple" }, "apple" },
            new object[] { new string[] { "a", "b", "ba", "bac", "bad" }, "bac" }
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new Solution()
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestLongestWord(string[] words, string expected)
    {
        foreach (var solution in _solutions)
        {
            string result = solution.LongestWord(words);
            Assert.Equal(expected, result);
        }
    }
}
