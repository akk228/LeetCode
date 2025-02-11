namespace LeetCode.Topics.BitManipulation.FindIfArrayCanBeSorted;

public class Tests
{
    [Fact]
    public void CanBeSorted()
    {
        int[] data = [2,28,9]; //[8, 4, 2, 30, 15];
        var canBeSorted = false;
        var result = new Solution().CanSortArray(data);
        
        Assert.Equal(canBeSorted, result);
    }
}