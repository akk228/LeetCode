namespace LeetCode.Topics.DynamicProgramming.Medium.MinimumNumberOfRemovalsToMakeMountainArray;

public class Solution {
    private class Node(int value, int increasingSequence = 0, int decreasingSequence = 0)
    {
        public int Value { get; } = value;
        public int IncreasingSequence { get; set; } = increasingSequence;
        public int DecreasingSequence { get; set; } = decreasingSequence;
        public bool IsMountain => IncreasingSequence > 0 && DecreasingSequence > 0;
        public int MountainLength => IsMountain ? IncreasingSequence + DecreasingSequence + 1 : 0;
    }
    
    public int MinimumMountainRemovals(int[] nums)
    {
        var topHills = new Node[nums.Length];
        
        topHills[0] = new (nums[0]);
        topHills[^1] = new (nums[^1]);

        for (var i = 1; i < nums.Length - 1; i++)
        {
            var maxIncreasingSequence = 0;
            var steepExists = false;
            for (int j = 0; j < i; j++)
            {
                if (topHills[j].Value >= nums[i]) continue;
                steepExists = true;
                    
                if(topHills[j].IncreasingSequence > maxIncreasingSequence)
                    maxIncreasingSequence = topHills[j].IncreasingSequence;
            }
            
            topHills[i] = new (nums[i], !steepExists ? 0 : maxIncreasingSequence + 1);
        }

        for (var i = nums.Length - 2; i > 0; i--)
        {
            var maxDecreasingSequence = 0;
            var steepExists = false;
            
            for (var j = nums.Length - 1; j > i; j--)
            {
                if (topHills[j].Value >= nums[i]) continue;
                steepExists = true;
                if ( topHills[j].DecreasingSequence > maxDecreasingSequence)
                    maxDecreasingSequence = topHills[j].DecreasingSequence;
            }
            
            topHills[i].DecreasingSequence = !steepExists ? 0 : maxDecreasingSequence + 1;
        }
        
        var minDeletions = nums.Length;

        foreach (var t in topHills)
        {
            var deletions = topHills.Length - t.MountainLength;
            if(deletions < minDeletions && t.IsMountain) minDeletions = deletions;
        }
        
        return minDeletions;
    }
}