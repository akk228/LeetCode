namespace LeetCode.Topics.Matrix.Medium.CountUnguardedCellsInTheGrid;

public class Tests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>()
    {
        new object[]{4, 6, (int[][])[[0,0],[1,1],[2,3]], (int[][])[[0,1],[2,2],[1,4]], 7}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void CountUnguardedCellsInTheGrid(int m, int n, int[][] guards, int[][] walls, int expectedCount)
    {
        var actualCount = new Solution().CountUnguarded(m, n, guards, walls);
        
        Assert.Equal(expectedCount, actualCount);
    }
}