namespace LeetCode.Topics.Sorting.Medium.KthLargestElement;

public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        if(nums.Length == 0) return nums[0];
        int q = nums.Length - k;
        QuickSelect(nums, 0, nums.Length - 1, q);
        return nums[q];
    }

    private void QuickSelect(int[] nums, int start, int end, int k){
        int pivot = Partition(nums, start, end);

        if(pivot == k) return;
        if(pivot < k) QuickSelect(nums, pivot + 1, end, k);
        else QuickSelect(nums, start, pivot - 1, k);
    }

    private int Partition(int[] nums, int start, int end)
    {
        int pivot = new Random().Next(start, end);
        int pivotElement = nums[pivot];

        (nums[pivot], nums[end]) = (nums[end], nums[pivot]);

        int pivotIndex = start;

        for(int i = start; i < end; i++){
            if(nums[i] < pivotElement) 
            {
                (nums[i], nums[pivotIndex]) = (nums[pivotIndex], nums[i]);
                pivotIndex++;
            }
        }
        
        (nums[end], nums[pivotIndex]) = (nums[pivotIndex], nums[end]);

        return pivotIndex;
    }
}