namespace LeetCode.Topics.DynamicProgramming.Medium.ApproximateStringMatching;

public class StringComparerTests
{
    public static IEnumerable<object[]> GetStringComparerTestData() => new List<object[]>()
    {
        new object[]{"ab", "ab", 0},
        new object[]{"ab", "ac", 1},
        new object[]{"abc", "ac", 1},
        new object[]{"", "bc", 2},
        new object[]{"abc", "bc", 1},
        new object[]{"aaa", "bbb", 3},
        new object[]{"aaa", "bbbb", 4},
    };

    [Theory]
    [MemberData(nameof(GetStringComparerTestData))]
    public void ReturnsCorrectCostOfTransformationOfPatternToString(string text, string pattern, int cost)
    {
        var actualCost = StringComparer.CompareCost(text, pattern, text.Length - 1, pattern.Length - 1);
        Assert.Equal(cost, actualCost);
    }
}