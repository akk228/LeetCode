namespace LeetCode.Topics.Heap.Hard.ShortestSubArrayWithSumAtLeastK;

public class Solution1 : ISolution
{
    public int ShortestSubarray(int[] nums, int k)
    {
        var minLength = Int32.MaxValue;
        long cumulativeSum = 0;
        var cumulativeSumHeap = new PriorityQueue<int, long>();
        
        // Loop invariant:
        // 1) for each i, nums[i] becomes a sum of all elements smaller or equal than nums[i]
        // 2) minLength keeps the min length of sub array from 0 to some j such that j <= i
        // 3) index of every element in priority queue is less or equal than i
        for (var i = 0; i < nums.Length; i++)
        {
            cumulativeSum += nums[i];

            if (cumulativeSum >= k) minLength = Math.Min(minLength, i + 1);
            
            cumulativeSumHeap.Enqueue(i, cumulativeSum);

            if (!cumulativeSumHeap.TryPeek(out int index, out long lowestCumulativeSum)) continue;
            
            while (cumulativeSum - lowestCumulativeSum >= k)
            {
                var length = i - index;
                if(length < minLength) minLength = length;
                cumulativeSumHeap.Dequeue();
                if (!cumulativeSumHeap.TryPeek(out index, out lowestCumulativeSum)) break;
            }
        }
        
        return minLength > nums.Length ? -1 : minLength;
    }
}