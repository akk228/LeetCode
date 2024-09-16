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
        
        CheckHeapIsCorrect(0, heap.GetHeap);
    }

    private void CheckHeapIsCorrect(int node, List<int> heap)
    {
        if (node >= heap.Count)
        {
            Assert.True(true);
            return;
        }
        int leftChild = MaxHeap.GetLeftChild(node);
        int rightChild = MaxHeap.GetRigthChild(node);
        
        if((leftChild < heap.Count && heap[node] < heap[leftChild])
           || ( rightChild < heap.Count && heap[node] < heap[rightChild]))
            Assert.True(false);
        
        CheckHeapIsCorrect(MaxHeap.GetLeftChild(node), heap);
        CheckHeapIsCorrect(MaxHeap.GetRigthChild(node), heap);
    }
}