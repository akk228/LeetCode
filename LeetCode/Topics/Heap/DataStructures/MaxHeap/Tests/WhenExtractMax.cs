namespace LeetCode.Topics.Heap.DataStructers.MaxHeap.Tests;

public class WhenExtractMax
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>()
        {
            new object[]{ new []{1, 2, 3, 4}, 4},
            new object[]{ new [] {8,3,3,9,5}, 9}
        };
    [Theory]
    [MemberData(nameof(TestData))]
    public void HeapIsCorrect(int[] nums, int expected)
    {
        var heap = new MaxHeap(nums.ToList());
        Assert.Equal(expected, heap.ExtractMax());
        
        TestHelper.CheckHeapIsCorrect(0, heap.GetHeap);
    }
    
    
}