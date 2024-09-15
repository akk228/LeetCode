namespace LeetCode.Topics.DynamicProgramming.Medium.CoinChange;

public class Tests
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]{ new int[]{1, 2, 5} , 11, 3},
            new object[]{ new int[]{1}, 2, 2},
            new object[]{ new int[]{3}, 2, -1},
            new object[]{ new int[]{2, 4, 5}, 4, 1},
            new object[]{ new int[]{2, 5, 10, 1}, 27, 4}
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void CorrectResult(int[] coins, int amount, int expectedResult)
    {
        var solution = new Solution();
        var actualResult = solution.CoinChange(coins, amount);
        
        Assert.Equal(actualResult, expectedResult);
    }
}