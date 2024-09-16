namespace LeetCode.Topics.Heap.DataStructers.MaxHeap;

public class MaxHeap
{
    private readonly List<int> _heap;

    public MaxHeap()
    {
        _heap = new List<int>();
    }

    public MaxHeap(List<int> nums)
    {
        _heap = new List<int>();
        foreach (var num in nums)
        {
            _heap.Add(num);
            HeapUp();
        }
    }

    public List<int> GetHeap => _heap.ToList();
    
    private void HeapUp()
    {
        var index = _heap.Count - 1;
        while (GetParent(index) >= 0 && _heap[index] > _heap[GetParent(index)])
        {
            var parentIndex = GetParent(index);
            if (_heap[parentIndex] < _heap[index])
            {
                (_heap[parentIndex], _heap[index]) = (_heap[index], _heap[parentIndex]);
                index = parentIndex;
            }
        }
    }

    public static int GetLeftChild(int parentIndex)
    {
        return 2*parentIndex + 1;
    }
    
    public static int GetRigthChild(int parentIndex)
    {
        return 2*(parentIndex + 1);
    }

    public static int GetParent(int childIndex)
    {
        return (childIndex - 1) / 2;
    }
}