namespace LeetCode.Helpers;

public static class ArraysHelper
{
    public static bool HasSameContents<T>(this ICollection<T> list1, ICollection<T> list2) 
        where T : IComparable<T>
    {
        list1.Order(Comparer<T>.Create((x, y) => x.CompareTo(y)));
        var result = list1.Except(list2,
            EqualityComparer<T>.Create( (x, y) =>
            {
                if (x is null && y is null) return true;
                if (x is null && y is not null ||
                    y is null && x is not null)
                    return false;
                
                return x?.CompareTo(y) == 0;
            }));

        return !result.Any() && list1.Count() == list2.Count();
    }
}