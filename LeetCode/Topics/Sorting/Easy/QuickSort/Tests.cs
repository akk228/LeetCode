namespace LeetCode.Topics.Sorting.Easy.QuickSort;

public class Tests
{
    private readonly Solution _solution = new Solution();
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Sorted(int[] arr)
    {
        _solution.quickSort(arr, 0, arr.Length - 1);
        CheckResult(arr);
    }
    
    private void CheckResult(int [] arr)
    {
        for (int i = 1; i < arr.Length; ++i)
        {
            if(arr[i - 1] > arr[i]) Assert.True(false);
        }
        Assert.True(true);
    }
    
    public static IEnumerable<object[]> TestData =>
        new List<object[]>()
        {
             new object[] { new[] { 4, 1, 3, 9, 7 } },
             new object[] { new[] { 1, 2, 3, 4, 1 } },
             new object[] { new[] { 1, 2, 3} },
             new object[] { new[] { 1, 1, 1, 1, 1 } },
             new object[] { new[] { 1, 1} }
        };

}