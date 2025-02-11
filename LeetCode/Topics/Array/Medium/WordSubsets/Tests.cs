namespace LeetCode.Topics.Array.Medium.WordSubsets;

public class Tests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>()
    {
        new object[] { (string[])["acaac","cccbb","aacbb","caacc","bcbbb"], (string[])["c","cc","b"], (string[])["cccbb"] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void WordSubsetsTest(string[] words, string[] refWords, string[] expected)
    {
        var solution = new Solution().WordSubsets(words, refWords).ToArray();
        
        System.Array.Sort(solution);
        System.Array.Sort(expected);
        
        Assert.Equal(expected, solution);
    }
}