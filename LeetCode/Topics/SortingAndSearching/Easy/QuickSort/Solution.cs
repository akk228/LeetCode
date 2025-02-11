namespace LeetCode.Topics.Sorting.Easy.QuickSort;

class Solution {
    // Function to sort an array using quick sort algorithm.
    public void QuickSort(int[] arr, int low, int high) {
        if (low >= high) return;
        
        var pivot = Partition(arr, low, high);
        
        QuickSort(arr, low, pivot - 1);
        QuickSort(arr, pivot + 1, high);
    }

    /// <summary>
    /// Partition splits the given range, such that all elements
    /// less or equal to the pivot element are on the left, and
    /// elements larger are on the right.
    /// </summary>
    /// <param name="arr">array of numbers to be partitioned</param>
    /// <param name="low">starting index of the sequence to be partitioned</param>
    /// <param name="high">finishing index of the sequence to be partitioned</param>
    /// <returns>position of pivotal point</returns>
    public int Partition(int[] arr, int low, int high) {
        var pivot = low;
        (arr[pivot], arr[high]) = (arr[high], arr[pivot]);
        
        while (low < high)
        {
            if (arr[low] <= arr[high])
            {
                (arr[low], arr[pivot]) = (arr[pivot], arr[low]);
                pivot++;
            }
            
            low++;
        }
        
        (arr[high], arr[pivot]) = (arr[pivot], arr[high]);
        
        return pivot;
        
    }
}