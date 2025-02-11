namespace LeetCode.Topics.Greedy.Medium.JumpGame;

/// <summary>
/// 55. Jump Game
/// </summary>
/// <remarks>
/// Beats : 100% in time, and 55.56% in space
/// </remarks>
public class Solution {
    public bool CanJump(int[] nums) {
        if(nums.Length == 1) return true;

        var reach = 0;
        var lastIndex =  nums.Length - 1;

        for (var pos = 0; pos <= lastIndex; pos++){
            var maxJump = pos + nums[pos];
            if (maxJump >= lastIndex) return true;
            if (maxJump > reach) reach = maxJump;
            if (nums[pos] == 0 && pos == reach) return false;
        }

        return true;
    }
}