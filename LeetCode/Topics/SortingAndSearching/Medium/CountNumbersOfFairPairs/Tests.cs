namespace LeetCode.Topics.SortingAndSearching.Medium.CountNumbersOfFairPairs;

public class SortingTests
{
    public static IEnumerable<object[]> TestData => new List<object[]>()
    {
        new object[] { (int[])[0,1,7,4,4,5], 3, 6, 6},
        new object[] {(int[])[1,7,9,2,5], 11, 11, 1},
        new object[] {(int[])[0,0,0,0,0,0], 0, 0, 15},
        new object[] {(int[])[-5,-7,-5,-7,-5], -12, -12, 6},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void CorrectNumberOfPairs(int[] nums, int lower, int upper, int expectedCount)
    {
        var actualCount = new Solution().CountFairPairs(nums, lower, upper);
        Assert.Equal(expectedCount, actualCount);
    }
}