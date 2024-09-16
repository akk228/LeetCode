namespace LeetCode.Topics.Heap.DataStructers.MaxHeap.Tests;

public class TestHelper
{
    public static void CheckHeapIsCorrect(int node, List<int> heap)
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