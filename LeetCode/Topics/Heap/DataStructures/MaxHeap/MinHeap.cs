namespace LeetCode.Topics.Heap.DataStructures.MaxHeap;

public class MinHeap<T> where T : IComparable<T>
{
    private readonly List<T> _heap = new List<T>(0);

    public MinHeap()
    {
    }
    
    public MinHeap(IEnumerable<T> items)
    {
        foreach (var item in items) Add(item);
    }

    public int Count => _heap.Count;
    
    public T GetMin() => _heap[0];

    public void Add(T item)
    {
        _heap.Add(item);
        HeapUp(_heap.Count - 1);
    }

    public T ExtractMin()
    {
        var min = _heap[0];
        (_heap[0], _heap[^1]) = (_heap[^1], _heap[0]);
        _heap.RemoveAt(_heap.Count - 1);
        HeapDown(0);

        return min;
    }
    private void HeapUp(int index)
    {
        var parent = GetParent(index);
        
        // loop invariant is that all children of the element at index have strictly smaller value,
        // and if it swaps parent if index element with itself only if parent has larger value, thus, invariant is preserved
        while (parent >= 0 && _heap[parent].CompareTo(_heap[index]) > 0)
        {
            (_heap[index], _heap[parent]) = (_heap[parent], _heap[index]);
            parent = GetParent(index = parent);
        }
    }

    private void HeapDown(int index)
    {
        var left = GetLeftChild(index);
        var right = GetRightChild(index);

        while (left < _heap.Count)
        {
            var comparisonChildIndex = left;
            if (right < _heap.Count && _heap[left].CompareTo(_heap[right]) > 0) comparisonChildIndex = right;
            if (_heap[index].CompareTo(_heap[comparisonChildIndex]) > 0)
            {
                (_heap[index], _heap[comparisonChildIndex]) = (_heap[comparisonChildIndex], _heap[index]);
                index = comparisonChildIndex;
                left = GetLeftChild(index);
                right = GetRightChild(index);
            }
            else
            {
                break;
            }
        }
    }
    
    private int GetLeftChild(int parentIndex) => 2 * parentIndex + 1;
    private int GetRightChild(int parentIndex) => 2 * parentIndex + 2;
    private int GetParent(int childIndex) => (childIndex - 1) / 2;
}