namespace LeetCode.Topics.DynamicProgramming.Medium.CountWaysToBuildGoodStrings;

public class Solution
{
    public int CountGoodStrings(int low, int high, int zero, int one)
    {
        var goodStringCounts = new int[high + 1];

        goodStringCounts[zero] = goodStringCounts[one] = 1;
        if (zero == one) goodStringCounts[zero] = 2;

        for (var length = Math.Min(zero, one) + 1; length <= high; length++)
        {
            if (length >= zero)
            {
                goodStringCounts[length] += goodStringCounts[length - zero];
            }
            if (length >= one)
            {
                goodStringCounts[length] += goodStringCounts[length - one];
            }
            goodStringCounts[length] %= 1000000007;
        }

        var sum = 0;

        for (var length = low; length <= high; length++)
        {
            sum += goodStringCounts[length];
            sum %= 1000000007;
        };

        return sum;
    }
}