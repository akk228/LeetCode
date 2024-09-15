namespace LeetCode.Topics.Sorting.Medium.KthLargestElement;

public class Tests
{
    // [3,2,1,5,6,4]
    private readonly Solution _solution = new Solution();

    public static IEnumerable<object[]> TestData =>
        new List<object[]>()
        {
            new object[] { new[] { 3,2,1,5,6,4 }, 2, 3 },
            new object[] { new[] {3,2,3,1,2,4,5,5,6}, 4 , 4}
        };
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Sorted(int[] arr, int k, int expected)
    {
        var actual = _solution.FindKthLargest(arr, k);
        Assert.Equal(actual, expected);
    }
}