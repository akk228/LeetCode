namespace LeetCode.Topics.TwoPointers.Medium.ShortestSubArrayToBeRemovedToMakeArraySorted;

public class Tests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>
    {
        new object[] { (int[])[1,2,3,10,0,7,8,9], 2},
        new object[] { (int[])[1,2,3,10,4,2,3,5], 3},
        new object[] { (int[])[5,4,3,2,1], 4},
        new object[] { (int[])[1,2,3], 0},
        new object[] { (int[])[6,3,10,11,15,20,13,3,18,12], 8},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void FoundCorrectNumberOfElementsToDelete(int[] input, int expected)
    {
        var result = new Solution().FindLengthOfShortestSubarray(input);
        
        Assert.Equal(expected, result);
    }
}