namespace LeetCode.Topics.Heap.Easy.FindXSumOfAllKLongSubArraysI;

public class Solution
{
    public int[] FindXSum(int[] nums, int k, int x)
    {
        var counters = new int[51];
        var result = new int[nums.Length - k + 1];

        for (var i = 0; i < k; i++) counters[nums[i]]++;

        result[0] = ComputeSubArraySum(counters, x);
        
        for (var i = k; i < nums.Length; i++)
        {
            counters[nums[i - k]] = Math.Max(counters[nums[i - k]] - 1, 0);
            counters[nums[i]]++;

            result[i - k + 1] = ComputeSubArraySum(counters, x);
        }

        return result;
    }

    private int ComputeSubArraySum(int[] counters, int maxCount)
    {
        var sum = 0;
        var frequencyQueue = new PriorityQueue<(int, int), (int, int)>(
            counters
                .Select( (frequency, value) => (frequency, value))
                .Where(tuple => tuple.frequency > 0)
                .Select(tuple => (tuple, tuple))
            );

        while (frequencyQueue.Count > maxCount) frequencyQueue.Dequeue();

        foreach (var elementPriority in frequencyQueue.UnorderedItems)
        {
            sum += elementPriority.Item1.Item1 * elementPriority.Item1.Item2;
        }
        
        return sum;
    }
}