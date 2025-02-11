namespace LeetCode.Topics.BitManipulation.MaximumXorForEachQuery;
using System;
/// <summary>
/// 1829. Maximum XOR for each query
/// Beat: 100% time, 75% memory
/// </summary>
public class Solution 
{
    public int[] GetMaximumXor(int[] nums, int maximumBit)
    {
        var mask = (1 << maximumBit) - 1;
        var query = nums[0];

        nums[0] = query ^ mask;
        
        for (var i = 1; i < nums.Length; i++)
        {
            query ^= nums[i];
            nums[i] = query ^ mask;    
        }

        Array.Reverse(nums);

        return nums;
    }
}