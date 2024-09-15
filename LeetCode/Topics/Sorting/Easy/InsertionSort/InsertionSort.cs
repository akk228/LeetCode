namespace LeetCode.Topics.Sorting.Easy.InsertionSort;

public static class InsertionSort
{
    public static void SortAscending(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            var j = i;
            while (j > 0 && arr[j - 1] > arr[j])
            {
                (arr[j - 1], arr[j]) = (arr[j], arr[j - 1]);
                j--;
            }
        }
    }
}