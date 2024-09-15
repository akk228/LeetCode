namespace LeetCode.Topics.Sorting.Easy.SelectionSort;

public static class SelectionSort
{
    /// <summary>
    /// In-place unstable sorting
    /// </summary>
    /// <param name="arr"></param>
    public static void Sort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            var indexOfSmallestElement = i;

            for (int j = i; j < arr.Length; j++)
            {
                if (arr[j] < arr[indexOfSmallestElement])
                {
                    indexOfSmallestElement = j;
                }
            }

            (arr[i], arr[indexOfSmallestElement]) = (arr[indexOfSmallestElement], arr[i]);
        }
    }
}