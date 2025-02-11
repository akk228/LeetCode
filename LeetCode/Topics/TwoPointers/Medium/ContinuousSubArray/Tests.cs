namespace LeetCode.Topics.TwoPointers.Medium.ContinuousSubArray;

public class Tests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>()
    {
        new object[] { (int[])[5,4,2,4], 8 },
        new object[] { (int[])[1,2,3], 6 },
        new object[] { (int[])[42,41,42,41,41,40,39,38], 28 },
        new object[] { (int[])[52,51,50,49,48,49,48,47,46], 29 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void RunTests(int[] arr, int expected)
    {
        var result = new Solution().ContinuousSubarrays(arr);
        
        Assert.Equal(expected, result);
    }
}