namespace LeetCode.Topics.BitManipulation.MaximumAndSubArray;

public class Solution
{
    public int MaxAndSubArrayValue(int[] nums)
    {
        var sum = nums.Max();

        foreach (var num in nums)
        {
            var result = num & sum;
            if (result > sum) sum = result;
        }

        return sum;
    }
}