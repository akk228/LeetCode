namespace LeetCode.Topics.DynamicProgramming.Medium.MinimumNumberOfRemovalsToMakeMountainArray;

public class MinimumNumberOfRemovalsToMakeMountainArrayTests
{
    private readonly Solution _solution = new();
    public static IEnumerable<object[]> TestData() => new List<object[]>(new []
    {
        new object[]{ new []{2,1,1,5,6,2,3,1}, 3},
        new object[]{ new []{1,3,1}, 0},
        new object[]{ new []{100,92,89,77,74,66,64,66,64}, 6}
    });

    [Theory]
    [MemberData(nameof(TestData))]
    public void FoundCorrectNumberOfRemovals(int[] nums, int expected)
    {
        var minNumberOfRemovalsToMakeMountainArray = _solution.MinimumMountainRemovals(nums);
        Assert.Equal(expected, minNumberOfRemovalsToMakeMountainArray);
    }
}