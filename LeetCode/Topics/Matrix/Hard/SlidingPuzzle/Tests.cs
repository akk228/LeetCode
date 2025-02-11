namespace LeetCode.Topics.Matrix.Hard.SlidingPuzzle;

public class Tests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>()
    {
        new object[] { (int[][])[[1,2,3],[4,0,5]], 1},
        new object[] { (int[][])[[1,2,3],[5,4,0]], -1},
        new object[] { (int[][])[[4,1,2],[5,0,3]], 5},
        new object[] { (int[][])[[3,2,4],[1,5,0]], 14},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void FindCorrectMinPathLength(int[][] board, int expectedMinPathLength)
    {
        var actualMinPathLength = new Solution().SlidingPuzzle(board);
        Assert.Equal(expectedMinPathLength, actualMinPathLength);
    }
}