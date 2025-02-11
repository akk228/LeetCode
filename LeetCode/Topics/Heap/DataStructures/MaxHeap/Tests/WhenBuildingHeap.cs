namespace LeetCode.Topics.Heap.DataStructers.MaxHeap.Tests;

public class WhenBuildingHeap
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>()
        {
            new []{ new []{1, 2, 3, 4}},
            new[]{ new [] {8,3,3,9,5}}
        };
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void ShouldBuildCorrectHeap(int[] arr)
    {
        var heap = new MaxHeap(arr.ToList());
        
        TestHelper.CheckHeapIsCorrect(0, heap.GetHeap);
    }
}