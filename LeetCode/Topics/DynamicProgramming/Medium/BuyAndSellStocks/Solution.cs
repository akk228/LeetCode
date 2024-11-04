namespace LeetCode.Topics.DynamicProgramming.Medium.BuyAndSellStocks;

public class Solution {
    public int MaxProfit(int[] prices) {
        var maxProfit = 0;
        
        for (var i = 0; i < prices.Length; i++)
        {
            var currentProfit = GetProfit(i, i, prices);
            maxProfit = Math.Max(maxProfit, currentProfit);
        }

        return maxProfit;
    }

    private int GetProfit(int dayBought, int currentDay, int[] prices)
    {
        if (dayBought == prices.Length - 1) return 0;
        if (currentDay == prices.Length - 1) return prices[currentDay] - prices[dayBought];
        
        var profitIfSoldToday = 
            prices[currentDay] - prices[dayBought] +
            GetProfit(currentDay + 1, currentDay + 1, prices);
        
        var profitIfSoldLater = 0;
        
        for (var i = currentDay + 1; i < prices.Length; i++)
        {
            profitIfSoldLater = Math.Max(
                GetProfit(dayBought, i, prices),
                profitIfSoldLater
                );
        }
        
        
        return Math.Max(profitIfSoldToday, profitIfSoldLater);
    }
}