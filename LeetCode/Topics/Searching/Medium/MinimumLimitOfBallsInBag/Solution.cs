namespace LeetCode.Topics.Searching.Medium.MinimumLimitOfBallsInBag;

/// <summary>
/// 1760. Minimum Limit of Balls in a Bag
/// </summary>
public class Solution
{
    public int MinimumSize(int[] nums, int maxOperations)
    {
        int min = 1, max = nums.Max();
        int mid = 0;

        while (min < max)
        {
            mid = (max + min) / 2;

            if (IsPossible(nums, mid, in maxOperations))
            {
                max = mid;
            }
            else
            {
                min = mid + 1;
            }
        }

        return min;
    }

    private bool IsPossible(int[] nums, int maxVal, in int maxOperations)
    {
        var splittings = 0;

        foreach(var num in nums)
        {
            if (num > maxVal)
            {
                splittings += (num / maxVal) +  (num % maxVal != 0 ? 1 : 0) - 1;
                if (splittings > maxOperations)
                {
                    return false;
                }
            }
        }

        return true;
    }
}