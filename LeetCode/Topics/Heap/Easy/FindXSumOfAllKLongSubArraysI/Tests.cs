namespace LeetCode.Topics.Heap.Easy.FindXSumOfAllKLongSubArraysI;

public class Tests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>()
    {
        new object[] { (int[])[1,1,2,2,3,4,2,3], 6, 2, (int[])[6,10,12]}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void CalcualteSumOfAllKLongSubArraysI(int[] nums, int k, int x, int[] expectedSum)
    {
        var resultingSum = new Solution().FindXSum(nums, k, x);
        
        Assert.Equal(expectedSum, resultingSum);
    }
}