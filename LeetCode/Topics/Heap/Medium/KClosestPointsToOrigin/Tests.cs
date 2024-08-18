namespace LeetCode.Topics.Heap.Medium.KClosestPointsToOrigin;

public class Tests
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]{ (int[][])[[3,3],[5,-1],[-2,4]], 2, (int[][])[[3,3],[-2,4]]}
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void CorrectResult(int[][] points, int k, int[][] expectedResult)
    {
        var solution = new Solution();
        var actualResult = solution.KClosest(points, k);
        
        Assert.True(
            !expectedResult.Except(actualResult).Any()
            && expectedResult.Length == actualResult.Length);
    }
}