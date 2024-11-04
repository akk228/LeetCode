namespace LeetCode.Topics.DynamicProgramming.Medium.LongestSquareStreakInAnArray;

public class Solution {
    public int LongestSquareStreak(int[] nums)
    {
        
        Array.Sort(nums);
        var squareStrikes = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            var square = num * num;

            if (squareStrikes.ContainsKey(num))
            {
                squareStrikes.TryAdd(square, squareStrikes[num] + 1);
            }
            else
            {
                squareStrikes.TryAdd(square, 1);
            }
        }

        var max = squareStrikes.Values.Max();
        
        return max > 1 ? max : -1;
    }
}