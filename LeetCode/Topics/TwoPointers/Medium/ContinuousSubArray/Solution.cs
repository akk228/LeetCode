namespace LeetCode.Topics.TwoPointers.Medium.ContinuousSubArray;

public class Solution 
{
    public long ContinuousSubarrays(int[] nums)
    {
        var min = 0;
        var max = nums[0];

        var left = 0;
        var right = 0;
        long validSubArrayCount = 0;

        for (right = 0; right < nums.Length; right++)
        {
            min = Math.Min(min, nums[right]);
            max = Math.Max(max, nums[right]);

            if (max - min <= 2) continue;

            validSubArrayCount += SubArrayCount(right - left);
            left = right;
            min = max = nums[right];

            while (left > 0 && Math.Abs(nums[right] - nums[left - 1]) <= 2)
            {
                left--;
                min = Math.Min(min, nums[left]);
                max = Math.Max(max, nums[left]);
            }

            if (left < right) validSubArrayCount -= SubArrayCount(right - left);
        }
        
        return validSubArrayCount + SubArrayCount(right - left);
    }
    private long SubArrayCount(int length) => (length*((long)length + 1)) / 2;
}