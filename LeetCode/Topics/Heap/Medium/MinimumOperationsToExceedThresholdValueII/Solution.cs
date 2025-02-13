namespace LeetCode.Topics.Heap.Medium.MinimumOperationsToExceedThresholdValueII;

public class Solution : ISolution
{
    public int MinOperations(int[] nums, int k) {
        var numsQueue = new PriorityQueue<long, long>(
            nums.Where(y => y < k).Select(x => ((long)x, (long)x))
        );
        var count = 0;
        long newElement;

        while (numsQueue.Count > 1 && numsQueue.Peek() < k)
        {
            newElement = numsQueue.Dequeue()*2 + numsQueue.Dequeue();

            if (newElement < k)
            {
                numsQueue.Enqueue(newElement, newElement);
            }
            
            count++;
        }

        if (numsQueue.Count == 1) return count + 1;

        return count;
    }
}
