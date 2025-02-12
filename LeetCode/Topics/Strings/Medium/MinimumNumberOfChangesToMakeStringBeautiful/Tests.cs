using System.Diagnostics.CodeAnalysis;

namespace LeetCode.Topics.Strings.Medium.MinimumNumberOfChangesToMakeStringBeautiful;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>()
    {
        new object[]{"1010", 2},
        new object[]{"101010", 3},
        new object[]{"01010000011001001101", 6},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void FindCorrectMinimumNumberOfChanges(string s, int expected)
    {
        var actual = new Solution().MinChanges(s);
        Assert.Equal(expected, actual);
    }
}