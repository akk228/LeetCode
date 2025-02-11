namespace LeetCode.Topics.DynamicProgramming.Medium.GenerateParantheses;

public class Tests
{
    public static IEnumerable<object[]> TestData => new List<object[]>()
    {
        new object[]{1, new string[]{"()"}},
        new object[]{2, new string[]{"()()", "(())"}},
        new object[]{3, new string[]{"((()))","(()())","(())()","()(())","()()()"}},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void GeneratedCorrectCombinations(int pairNum, string[] expectedCombinations)
    {
        var actual = new Solution().GenerateParenthesis(pairNum);

        var result = actual.Except(expectedCombinations);
        
        Assert.True(!result.Any() && actual.Count == expectedCombinations.Length);
    }
}