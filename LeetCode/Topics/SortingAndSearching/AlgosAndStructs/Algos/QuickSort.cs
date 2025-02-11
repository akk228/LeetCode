using System.Collections.Concurrent;

namespace LeetCode.Topics.SortingAndSearching.AlgosAndStructs.Algos;

public static class QuickSort
{
    /// <summary>
    /// Does quick sort
    /// </summary>
    /// <param name="items">Elements to be sorted</param>
    /// <typeparam name="T"></typeparam>
    public static void Sort<T>(T[] items) where T : IComparable<T>
    {
        SortSubArray(items, 0, items.Length - 1);
    }
    
    /// <summary>
    /// Sorts subarray of items
    /// </summary>
    /// <param name="items">list if elements</param>
    /// <param name="start">index to start sorting from</param>
    /// <param name="end">index to finish sorting at</param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="IndexOutOfRangeException">Throws id end ot start indexes are out of bounds</exception>
    public static void SortSubArray<T>(T[] items, int start, int end) where T : IComparable<T>
    {
        if (end >= items.Length || start < 0) throw new IndexOutOfRangeException($"Endpoint {end} is out of range");
        if (start >= end) return;
        
        var pivotGenerator = new Random();
        var pivotIndex = pivotGenerator.Next(start, end);
        
        pivotIndex = Partition(items, start, end, pivotIndex);
        
        SortSubArray(items, start, pivotIndex - 1);
        SortSubArray(items, pivotIndex + 1, end);
    }

    /// <summary>
    /// Partitions array such that all elements that are less or equal to the element at Pivot Index are on the left side from pivot element
    /// </summary>
    /// <param name="items">elements to be partitioned</param>
    /// <param name="start">first index of the items to be partitioned</param>
    /// <param name="end">last index of the items to be partitioned</param>
    /// <param name="pivotIndex">Index of the value that would serve as the pivot</param>
    /// <returns>index where pivot element ends up</returns>
    private static int Partition<T>(T[] items, int start, int end, int pivotIndex) where T : IComparable<T>
    {
        var pivotValue = items[pivotIndex];

        (items[pivotIndex], items[end]) = (items[end], items[pivotIndex]);
        pivotIndex = start;
        
        while (start < end)
        {
            // We keep pivot index such that element at this index has greater value than pivot value.
            // This way we ensure that in case there are several elements that have same value as pivot value, our pivot would always mark occurence of the last one
            if (items[start].CompareTo(pivotValue) <= 0)
            {
                (items[start], items[pivotIndex]) = (items[pivotIndex], items[start]);
                pivotIndex++;
            }
            
            start++;
        }
        
        (items[pivotIndex], items[end]) = (items[end], items[pivotIndex]);
        
        return pivotIndex;
    }
}