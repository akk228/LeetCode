namespace LeetCode.Topics.Sorting.Easy.QuickSort;

class Solution {
    // Function to sort an array using quick sort algorithm.
    public void quickSort(int[] arr, int low, int high) {
        // code here
        if (low >= high) return;
        
        var pivot = Partition(arr, low, high, (low + high) / 2);
        
        quickSort(arr, low, pivot);
        quickSort(arr, pivot + 1, high);
    }

    // Function to divide array into two parts and return the index.
    public int Partition(int[] arr, int low, int high, int pivot) {
        while(low < high){
            if(arr[low] <= arr[pivot] && low < pivot) {
                ++low;
            }else {
                (arr[low], arr[pivot]) = (arr[pivot], arr[low]);
                pivot = low;
            }
            
            if(arr[high] > arr[pivot]) {
                --high;
            }else{
                (arr[high], arr[pivot]) = (arr[pivot], arr[high]);
                pivot = high;
            }
        }
        
        return pivot;
        
    }
}