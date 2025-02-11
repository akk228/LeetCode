namespace LeetCode.Topics.DynamicProgramming.Medium.BestTimeToBuyAndSellStocksII;

/// <summary>
/// 122. Best Time to Buy and Sell Stock II
/// </summary>
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        if (prices.Length == 1) return 0;

        var lastBuy = 0;
        var profit = 0;

        for (var day = 1; day < prices.Length; ++day)
        {
            if (prices[day] >= prices[day - 1]) continue;
            if (prices[day - 1] > prices[lastBuy])
            {
                profit += prices[day - 1] - prices[lastBuy];
            }

            lastBuy = day;
        }

        profit += prices[^1] - prices[lastBuy];

        return profit;
    }
}