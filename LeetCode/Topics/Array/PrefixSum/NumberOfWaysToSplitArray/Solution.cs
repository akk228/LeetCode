namespace LeetCode.Topics.Array.PrefixSum.NumberOfWaysToSplitArray;

public class Solution
{
    public int WaysToSplitArray(int[] nums)
    {
        var validSplits = 0;
        var prefixes = new long[nums.Length];
        
        prefixes[0] = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            prefixes[i] = nums[i] + prefixes[i - 1];
        }

        for (var i = 0; i < nums.Length - 1; i++)
        {
            if (prefixes[i] >= prefixes[^1] - prefixes[i]) validSplits++;
        }

        return validSplits;
    }
}