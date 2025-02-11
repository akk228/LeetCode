namespace LeetCode.Topics.DynamicProgramming.Medium.JumpGameII;

public class Solution
{
    public int Jump(int[] nums) {
        if (nums.Length == 1) return 0;

        var minJumpCount = new int[nums.Length];

        for (var pos = 1;pos < nums.Length && pos <= nums[0] ; pos++)
            minJumpCount[pos] = 1;

        for (var pos = 1; pos < nums.Length; ++pos)
        {
            if (minJumpCount[pos] == 0) continue;

            for (var i = 1; pos + i < nums.Length && i <= nums[pos]; i++)
                if(minJumpCount[pos + i] == 0)
                    minJumpCount[pos + i] = minJumpCount[pos] + 1;
        }

        return minJumpCount[^1];
    }
}