namespace LeetCode.Topics.DynamicProgramming.Medium.MaximumNumberOfMovesinGrid;

public class Tests
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]{ new int[][]{[2,4,3,5],[5,4,9,3],[3,4,2,11],[10,9,13,15]}, 3},
        };
    private readonly Solution solution = new Solution();
    [Theory]
    [MemberData(nameof(Data))]
    public void FindLongestSquareStreakInAnArray(int[][] grid, int expectedMaxPath)
    {
        var result = solution.MaxMoves(grid);
        
        Assert.Equal(expectedMaxPath, result);
    }
}