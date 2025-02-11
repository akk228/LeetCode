namespace LeetCode.Topics.SortingAndSearching.Medium.MostBeautifulItemForEachQuery;

public class Tests
{
    public static IEnumerable<object[]> TestData => new List<object[]>()
    {
        new object[]
        {
            (int[][])[[1,2],[3,2],[2,4],[5,6],[3,5]], 
            (int[])[1,2,3,4,5,6],
            (int[])[2,4,5,5,6,6]
        },
        new object[]
        {
            (int[][])[[124,431],[460,640],[263,940],[981,122],[845,113],[323,853],[836,419],[816,332],[622,765],[408,739],[143,389],[379,834],[308,592],[246,318],[372,732],[749,149],[549,559],[207,670],[764,102]], 
            (int[])[670,1452,613,304,1031,1454,390,822,842,184,324,429,255],
            (int[])[940,940,940,940,940,940,940,940,940,431,940,940,670]
        },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void ReturnsCorrectBeautyForEachQuery(int[][] items, int[] queries, int[] result)
    {
        var actualResult = new Solution().MaximumBeauty(items, queries);
        
        Assert.True(result.SequenceEqual(actualResult));
    }
}