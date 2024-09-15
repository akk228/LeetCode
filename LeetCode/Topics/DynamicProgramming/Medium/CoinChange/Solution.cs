namespace LeetCode.Topics.DynamicProgramming.Medium.CoinChange;

public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if(amount == 0) return 0;
        var amounts = new int [amount + 1];
        
        for (int i = 0; i <= amount; ++i)
        {
            amounts[i] = Int32.MaxValue;
        }
        
        for(int currentAmount = 1; currentAmount < amount + 1; currentAmount++){
            int result = amounts[currentAmount];

            foreach (var coin in coins.ToList().Order())
            {
                if (currentAmount - coin == 0)
                {
                    amounts[currentAmount] = 1;
                    result = Int32.MaxValue;
                    continue;
                }

                if (currentAmount - coin > 0 && amounts[currentAmount - coin] != Int32.MaxValue)
                {
                    result = Math.Min(result, amounts[currentAmount - coin]);
                }
            }

            if (result != Int32.MaxValue)
            {
                amounts[currentAmount] = ++result;
            }
        }

        return amounts[amount] == Int32.MaxValue ? - 1 : amounts[amount];
    }
}