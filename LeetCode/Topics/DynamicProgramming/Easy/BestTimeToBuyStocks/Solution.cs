namespace LeetCode.Topics.DynamicProgramming.Easy.BestTimeToBuyStocks;

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        // I need to keep current min, an current max, and kkep them as indexes to make sure 
        // i_min < i_max
        // max(nums[i_max] - nums[i_min])
        // Optimal substructure
        // let's say we have i_max(n) & i_min(n) such that for all i = 0,...,n
        // max_{I_max > i_min}(nums[i_max(n)] - nums[i_min(n)])
        // i increase length by 1
        // if nums[n+1] > nums[i_max] I can assign new i_max = n + 1
        // potential a new minimum can come up such that there will be i_new_max such
        // that nums[i_max_prev] > nums[i_max_new] but difference is larger
        // I can assign new min keep largest diff
        if (prices.Length == 1) return 0;

        var profit = 0;
        var min = 0;

        for (var day = 1; day < prices.Length; ++day)
            if(prices[day] - prices[min] > profit) profit = prices[day] - prices[min];
            else if (prices[day] < prices[min]) min = day;

        return profit;
    }
}