namespace LeetCode.Topics.BitManipulation.Medium.ShortestSubArrayWithOr;

public class Tests
{
    public static IEnumerable<object[]> TestData => new List<object[]>()
    {
        new object[]{new []{1,2,4}, 2, 1},
        new object[]{new []{2, 1, 8}, 10, 3},
        new object[]{new []{1, 2}, 0 ,1}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int k, int expectedResult)
    {
        var actualResult = new Solution().MinimumSubarrayLength(nums, k);
        Assert.Equal(expectedResult, actualResult);
    }
}