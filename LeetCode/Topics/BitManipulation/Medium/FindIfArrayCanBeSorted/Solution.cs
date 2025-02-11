namespace LeetCode.Topics.BitManipulation.FindIfArrayCanBeSorted;

/// <summary>
/// 3011. Find If Array Can Be Sorted
/// Constraints: 1 <= val <= 2^8, 1 <= length <= 100
/// </summary>
public class Solution
{
    public bool CanSortArray(int[] nums)
    {
        if (nums.Length == 1) return true;
        
        var leftMax = 0;
        var rightMin = nums[0];
        var rightMax = nums[0];
        var setBitCount = GetSetBits(nums[0]);
        
        for (var i = 1; i < nums.Length; i++)
        {
            var currBitCount = GetSetBits(nums[i]);

            if (currBitCount == setBitCount)
            {
                if (rightMin > nums[i]) rightMin = nums[i];
                if (rightMax < nums[i]) rightMax = nums[i];
                if (leftMax > rightMin) return false;
            }
            else
            {
                setBitCount = currBitCount;
                leftMax = rightMax;
                rightMax = nums[i];
                rightMin = nums[i];
                if (leftMax > nums[i]) return false;
            }
            
        }
        
        return true;
    }

    private int GetSetBits(int num)
    {
        var count = 0;
        while (num > 0)
        {
            count += num & 1;
            num >>= 1;
        }
        return count;
    }
}