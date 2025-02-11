namespace LeetCode.Topics.Heap.Hard.ShortestSubArrayWithSumAtLeastK;

public class Tests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>()
    {
        new object[] { (int[])[2,-1,2], 3, 3},
        new object[] { (int[])[-2,3,4,1], 5, 2},
        new object[] { (int[])[1,1,1,2], 4, 3},
        new object[] { (int[])[1], 1, 1},
        new object[] { (int[])[1,2], 4, -1},
        new object[] { (int[])[4934,72728,28459,17172,13090,93563,50447,-9866,-32292,30383,95736,-22858,20416,65242,-22343,-1736,56869,-24816,80113,-48157,49145,-7403,71979,24726,-21065,61149,54446,13294,25720,69296,84135,58611,34369,-14809,-33419,-36757,-34981,11341,-34333,79748,21005,-41146,21232,88408,63856,58004,-39644,23613,31001,94396], 202456, 3},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void RunTests(int[] nums, int k, int expectedSubArrayLength)
    {
        var actualSubArrayLength = (new Solution1() as ISolution).ShortestSubarray(nums, k );
        Assert.Equal(expectedSubArrayLength, actualSubArrayLength);
    }
}