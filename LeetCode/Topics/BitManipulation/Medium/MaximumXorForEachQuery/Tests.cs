namespace LeetCode.Topics.BitManipulation.MaximumXorForEachQuery;

public class Tests
{
    public static IEnumerable<object[]> TestData => new List<object[]>()
    {
        new object[]{ new []{0,1,1,3}, 2, new []{0,3,2,3}}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void CorrectQueries(int[] nums, int maxBit, int[] actualQueries)
    {
        var result = new Solution().GetMaximumXor(nums, maxBit);
        Assert.True(result.SequenceEqual(actualQueries));
    }
}