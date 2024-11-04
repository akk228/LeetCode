namespace LeetCode.Topics.DynamicProgramming.Medium.BuyAndSellStocks;

public class Tests
{
    private readonly Solution _solution = new();

    [Theory]
    [MemberData(nameof(Data))]
    public void TestCase(int[] prices, int expectedProfit)
    {
        var result = _solution.MaxProfit(prices);
        
        Assert.Equal(expectedProfit, result);
    }
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]{ new []{1}, 0},
            new object[]{ new []{1,2}, 1},
            new object[]{ new []{3,1}, 0},
            new object[]{ new []{1,2,3}, 2},
            new object[]{ new []{1,5,10,1}, 9},
            new object[]{ new []{1,2,3,4,5}, 4},
            new object[]{ new []{7,1,5,3,6,4}, 7},
        };
}