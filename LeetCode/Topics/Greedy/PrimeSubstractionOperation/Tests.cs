namespace LeetCode.Topics.Greedy.PrimeSubstractionOperation;

public class Tests
{
    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        // new object[]{ new []{2,2}, false},
        // new object[]{ new []{998,2}, true},
        new object[]{ new []{15, 15, 10}, true},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, bool isOrderable)
    {
        var actual = new Solution().PrimeSubOperation(nums);
        
        Assert.Equal(isOrderable, actual);
    }
}