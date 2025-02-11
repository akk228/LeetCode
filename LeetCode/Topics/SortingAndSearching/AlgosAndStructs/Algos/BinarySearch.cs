namespace LeetCode.Topics.SortingAndSearching.AlgosAndStructs.Algos;

public static class BinarySearch
{
    public static int FindUpperBound<T>(T[] items, int start, int end, T value) 
        where T : IComparable<T>
    {
        while (start <= end)
        {
            var mid = start + end >> 1;

            if (items[mid].CompareTo(value) < 0)
            {
                start = mid + 1;
            }
            else
            {
                end = mid - 1;
            }
        }
        
        return start < items.Length && items[start].CompareTo(value) <= 0 ? start : -1;
    }
}