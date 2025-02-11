namespace Greedy.Medium.MinimumDeletionsToMakeArrayBeautiful;

/// <summary>
/// 1909. Minimum Deletions to Make the Array Sorted
/// </summary>
public class Solution
{
    public int MinDeletion(int[] nums)
    {
        var count = 0;

        // loop inv: left part always satisifies 2nd beauty condition
        for (var i = 0; i < nums.Length - 1; i++)
        {
            if ((i - count) % 2 == 0 && nums[i + 1] == nums[i])
            {
                count++;
            }
        }

        return count + (nums.Length - count) % 2;
    }
}