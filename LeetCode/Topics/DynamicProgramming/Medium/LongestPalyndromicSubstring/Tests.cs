namespace LeetCode.Topics.DynamicProgramming.Medium.LongestPalyndromicSubstring;

public class Tests
{
    public static IEnumerable<object[]> TestData => new List<object[]>()
    {
        new object[]{ "a", 1},
        new object[]{ "aa", 2},
        new object[]{ "aaa", 3},
        new object[]{ "abac", 3},
        new object[]{ "abcd", 1},
        new object[]{ "abba", 4},
        new object[]{ "babad", 3}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void ReturnsCorrectLength(string s, int maxLength)
    {
        var actual = new DummySolution().LongestPalindrome(s);
        Assert.Equal(maxLength, actual.Length);
    }
}