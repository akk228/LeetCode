namespace LeetCode.Topics.Strings.Medium.StringCompressionIII;

public class Tests
{
    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[]{"abc", "1a1b1c"}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        Solution solution = new Solution();
        var actual = solution.CompressedString(input);
        
        Assert.Equal(expected, actual);
    }
}