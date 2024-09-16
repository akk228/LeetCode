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
    
    public void AddElement(int num)
    {
        _heap.Add(num);
        HeapUp();
    }

    public int ExtractMax()
    {
        int max = _heap[0];
        
        (_heap[0], _heap[^1]) = (_heap[^1], _heap[0]);
        _heap.RemoveAt(_heap.Count - 1);
        
        HeapDown();
        
        return max;
    }
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

    private void HeapDown()
    {
        int index = 0;

        while (true)
        {
            int swapIndex = index;
            int left = GetLeftChild(index);
            int right = GetRigthChild(index);

            if (left < _heap.Count && _heap[left] >= _heap[swapIndex])
            {
                (_heap[left], _heap[swapIndex]) = (_heap[swapIndex], _heap[left]);
                swapIndex = left;
            }

            if (right < _heap.Count && _heap[right] >= _heap[swapIndex])
            {
                (_heap[right], _heap[swapIndex]) = (_heap[swapIndex], _heap[right]);
                swapIndex = right;
            }

            if (swapIndex != index)
            {
                index = swapIndex;
            }
            else
            {
                break;
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