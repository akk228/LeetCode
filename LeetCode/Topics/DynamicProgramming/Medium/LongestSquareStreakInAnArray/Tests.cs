namespace LeetCode.Topics.DynamicProgramming.Medium.LongestSquareStreakInAnArray;

public class Tests
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]{ new []{4, 3, 6, 16, 8, 2} , 3},
            new object[]{ new []{2,3,5,6,7}, -1},
            new object[]{ new []{1}, -1},
            new object[]{ new []{1,2,2,4}, 2},
        };
    private readonly Solution solution = new Solution();
    [Theory]
    [MemberData(nameof(Data))]
    public void FindLongestSquareStreakInAnArray(int[] nums, int squareStreak)
    {
        var result = solution.LongestSquareStreak(nums);
        
        Assert.Equal(squareStreak, result);
    }
}