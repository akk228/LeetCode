namespace LeetCode.Topics.Heap.Medium.TopKFrequentElements;

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var elementsToFrequencies = new Dictionary<int,int>();

        foreach (var num in nums)
        {
            if (!elementsToFrequencies.TryAdd(num, 1))
            {
                elementsToFrequencies[num]++;
            }
        }

        var priorityQueue = new PriorityQueue<int, int>();

        foreach (var efPair in elementsToFrequencies)
        {
            priorityQueue.Enqueue(efPair.Key, efPair.Value);
        }

        while (priorityQueue.Count != k)
        {
            priorityQueue.Dequeue();
        }

        return priorityQueue.UnorderedItems.Select(x => x.Item1).ToArray();
    }
}