namespace LeetCode.Topics.Sorting.Medium.KthLargestElement;

public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        int start = 0;
        int end = nums.Length - 1;
        int smallCount = 0;
        int pivot = 0;
        while (start < end)
        {
            pivot = Partition(nums, start, end, ref smallCount);
            if (smallCount == k) break;
            if (smallCount < k) start = pivot;
            if (smallCount > k) end = pivot;
        }
        
        return nums[pivot];
    }

    int Partition(int [] segment, int start, int end, ref int smallCount)
    {
        int pivot = (start + end) / 2;

        while (start < end)
        {
            if (segment[start] < segment[pivot])
            {
                ++start;
                ++smallCount;
            }else if(segment[start] > segment[pivot])
            {
                (segment[pivot], segment[start]) = (segment[start], segment[pivot]);
                pivot = start;
            }
            else
            {
                pivot = start;
                start++;
            }

            if (segment[pivot] < segment[end]) --end;
            else
            {
                (segment[pivot], segment[end]) = (segment[start], segment[end]);
                pivot = end;
            }
        }

        return pivot;
    }
}