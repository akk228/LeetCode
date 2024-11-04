namespace LeetCode.Topics.Graphs.Medium.MinimunNumberOfArrowsToBurstBallons;

public class Tests
{
    private readonly Solution _solution = new Solution();
    public static IEnumerable<object[]> Data =>
        new List<object[]>()
        {
            new object[]{ new []{new[]{1,2}, [2,3], [3,4], [4,5]} , 2}
        };
    

    [Theory]
    [MemberData(nameof(Data))]
    public void DetectCycle(int[][] ballons, int numberOfArrows)
    {
        var actualNumOfArrows = _solution.FindMinArrowShots(ballons);
        
        Assert.Equal(numberOfArrows, actualNumOfArrows);
    }
}