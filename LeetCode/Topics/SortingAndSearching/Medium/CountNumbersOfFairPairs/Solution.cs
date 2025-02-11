namespace LeetCode.Topics.SortingAndSearching.Medium.CountNumbersOfFairPairs;

public class Solution
{
    public long CountFairPairs(int[] nums, int lower, int upper)
    {
        Array.Sort(nums);

        var count = 0;
        var lastIndex = nums.Length - 1;
        
        for (var i = 1; i < nums.Length; i++)
        {
            var diff =
                FindUpperBound(nums, i, lastIndex, upper - nums[i]) -
                FindUpperBound(nums, i, lastIndex, nums[i] - lower - 1);

            if (diff > 0) count += diff;
        }

        return count;
    }

    
    private int FindUpperBound(int[] nums, int left, int right, int edge)
    {
        while (left <= right)
        {
            var mid = (right + left) / 2;

            if (nums[mid] <= edge) left = mid + 1;
            else right = mid - 1;
        }
        return right;
    }
}