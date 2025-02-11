using System.Collections.Immutable;

namespace LeetCode.Topics.SortingAndSearching.Medium.MostBeautifulItemForEachQuery;

public class Solution
{
    private const int Price = 0;
    private const int Beauty = 1;
    
    public int[] MaximumBeauty(int[][] items, int[] queries)
    {
        Array.Sort(items, (a, b) =>
        {
            var result = a[Price].CompareTo(b[Price]);
            return result == 0 ? b[Beauty].CompareTo(a[Beauty]) : result;
        });
        
        var mostBeautiful = items[0][Beauty];
        
        for (var i = 1; i < items.Length; i++)
        {
            if (mostBeautiful > items[i][Beauty])
            {
                items[i][Beauty] = mostBeautiful;
            }
            else
            {
                mostBeautiful = items[i][Beauty];
            }
        }

        for (var i = 0; i < queries.Length; i++)
        {
            queries[i] = BinarySearch(items, queries[i]);
        }
        
        return queries;
    }

    private int BinarySearch(int[][] items, int query)
    {
        if (query < items[0][Price])
        {
            return 0;
        }
        var left = 0;
        var right = items.Length - 1;
        var mid = (right + left + 1) / 2;

        while (right > left)
        {
            if (items[mid][Price] == query)
            {
                return items[mid][Beauty];
            }
            else if (items[mid][Price] < query)
            {
                left = mid + 1 < items.Length ? mid + 1 : items.Length - 1;
                mid = (right + left + 1) / 2;
            }
            else
            {
                right = mid - 1 >= 0 ? mid - 1 : 0;
                mid = (right + left + 1) / 2;
            }
        }
        
        
        
        return items[mid][Price] > query ? items[mid - 1][Beauty] : items[mid][Beauty];
    }
}