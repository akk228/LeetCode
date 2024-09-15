namespace LeetCode.Topics.Sorting;

public static class TestHelper
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>()
        {
            new object[] { new[] { 4, 1, 3, 9, 7 } },
            new object[] { new[] { 1, 2, 3, 4, 1 } },
            new object[] { new[] { 1, 2, 3} },
            new object[] { new[] { 1, 1, 1, 1, 1 } },
            new object[] { new[] { 1, 1} },
            new object[] { new[] { 4, 1, 3, 9, 7 ,7, 19, 21, 2, 9, 9 } },
            new object[] { new[] { 4, 1, 3, 9, 7, 10, 2, 18 } },
        };
    
    public static bool IsOrderAscending(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
            if(arr[i - 1] > arr[i]) return false;

        return true;
    }
}