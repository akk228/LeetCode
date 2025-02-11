namespace LeetCode.Topics.Strings.Easy.StringMatchingInAnArray;

public class Tests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>()
    {
        new object[]{(string[])["abcd", "ab","cd"], (string[])["ab","cd"]},
        new object[]{(string[])["leetcode","et","code"], (string[])["et","code"]},
        new object[]{(string[])["blue","green","bu"], (string[])[]},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void FindCorrectSubStrings(string[] words, string[] expected)
    {
        var result = new Solution().StringMatching(words).ToArray();
        
        System.Array.Sort(result, (x, y) => String.Compare(x, y, StringComparison.Ordinal));
        System.Array.Sort(expected, (x, y) => String.Compare(x, y, StringComparison.Ordinal));
        
        Assert.Equal(expected, result);
    }
}