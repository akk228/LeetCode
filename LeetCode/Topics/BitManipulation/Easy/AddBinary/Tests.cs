namespace LeetCode.Topics.BitManipulation.Easy.AddBinary;

public class Tests
{
    public static IEnumerable<object[]> TestData => new List<object[]>()
    {
        new object[]{"1", "11", "100"},
        new object[]{"1010", "1011", "10101"},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string a, string b, string expectedResult)
    {
        var actualResult = new Solution().AddBinary(a, b);
        Assert.Equal(expectedResult, actualResult);
    }
}