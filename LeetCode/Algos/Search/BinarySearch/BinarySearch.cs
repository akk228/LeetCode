namespace LeetCode.Algos.Search.BinarySearch;

public static class BinarySearch<T> where T : IComparable<T>
{
    public static int Find(T[] array, T target)
    {
        int start = 0, end = array.Length - 1;
        int mid;
        // loop invariant: all elements less than or equal to target are on the left

        while (start < end)
        {
            mid = (start + end + 1) / 2;

            if (target.CompareTo(array[mid]) < 0)
            {
                // target < array[mid]
                end = mid - 1; // if I put here mid + 1, I can violate loop invariant
            }
            else
            {
                // target >= array[mid]
                start = mid;
            }
        }

        return array[start].CompareTo(target) == 0 ? start : -1;
    }

    public static int FindLessOrEqual(T[] array, T target)
    {
        int start = 0, end = array.Length - 1;
        int mid;

        while (start < end)
        {
            mid = (start + end) / 2;

            if (target.CompareTo(array[mid]) <= 0)
            {
                end = mid;
            }
            else
            {
                start = mid + 1;
            }
        }

        return -1;
    }
}