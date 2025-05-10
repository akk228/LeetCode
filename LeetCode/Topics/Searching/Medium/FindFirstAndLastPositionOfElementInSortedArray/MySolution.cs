using System;

namespace LeetCode.Topics.Searching.Medium.FindFirstAndLastPositionOfElementInSortedArray;

public class MySolution : ISolution
{
    public int[] SearchRange(int[] nums, int target) {
        if (nums.Length == 0)
        {
            return [-1, -1];
        }

        var start = FindStart(nums, target);

        if (start == -1)
        {
            return [-1, -1];
        }

        var end = FindEnd(nums, target);

        return [start, end];
    }

    private int FindStart(int[] nums, int target)
    {
        // all the elements on the left are strictly less than target
        var start = 0;
        var end = nums.Length - 1;

        while (start < end)
        {
            var mid = (start + end) / 2; // I land on the left or middle element
            // [0, 1] -> 0
            if (nums[mid] < target)
            {
                start = mid + 1;
            }
            else // target <= nums[mid]
            {
                end = mid;
            }
        }

        return nums[start] == target ? start : -1;
    }

    private int FindEnd(int[] nums, int target)
    {
        // all the elements on the left are strictly less than target
        var start = 0;
        var end = nums.Length - 1;

        while (start < end)
        {
            var mid = (start + end + 1) / 2;
            // [0, 1] -> 0
            if (nums[mid] <= target)
            {
                start = mid;
            }
            else // target < nums[mid]
            {
                end = mid - 1;
            }
        }

        return nums[start] == target ? start : -1;
    }
}