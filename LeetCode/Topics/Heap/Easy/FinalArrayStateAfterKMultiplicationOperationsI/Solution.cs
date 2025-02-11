using System.Runtime.CompilerServices;

namespace LeetCode.Topics.Heap.Easy.FinalArrayStateAfterKMultiplicationOperationsI;

public class Solution
{
    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        var heap = new Heap(nums);

        for (var i = 0; i < k; i++)
        {
            var minElement = heap.Extract();
            minElement.Value *= multiplier;
            heap.Add(minElement);
        }

        var elements = heap.GetHeap();

        foreach (var element in elements)
        {
            nums[element.Index] = element.Value;
        }
        
        return nums;
    }
    public class Heap
    {
        private readonly HeapElement[] _heap;
        private int _lastIndex;
        
        public Heap(int[] nums)
        {
            _heap = new HeapElement[nums.Length];

            for (var i = 0; i < _heap.Length; i++)
            {
                _heap[i] = new(nums[i], i);
                HeapifyUp(i);
            }
            
            _lastIndex = nums.Length - 1;
        }

        public HeapElement[] GetHeap() => _heap;
        public HeapElement Extract()
        {
            var root = _heap[0];
            _heap[0] = _heap[_lastIndex];
            _heap[_lastIndex] = default;
            _lastIndex--;
            
            HeapifyDown(0);
            
            return new(root.Value, root.Index);
        }
        
        public void Add(HeapElement heapElement)
        {
            if(_lastIndex == _heap.Length - 1) throw new IndexOutOfRangeException();
            _lastIndex++;
            _heap[_lastIndex] = heapElement;
            HeapifyUp(_lastIndex);
        }
        private void HeapifyUp(int index)
        {
            var parentIndex = ParentIndex(index);
            
            while (_heap[parentIndex] > _heap[index])
            {
                (_heap[index], _heap[parentIndex]) = (_heap[parentIndex], _heap[index]);
                index = parentIndex;
                parentIndex = ParentIndex(index);
            }
        }

        private void HeapifyDown(int index)
        {
            var leftChildIndex = LeftChild(index);
            var rightChildIndex = RightChild(index);

            while (true)
            {
                var indexToSwapWith = leftChildIndex;
                
                if (leftChildIndex > _lastIndex) break;
                if (rightChildIndex <= _lastIndex && _heap[rightChildIndex] < _heap[leftChildIndex]) indexToSwapWith = rightChildIndex;
                if (_heap[index] <= _heap[indexToSwapWith]) break;
                
                (_heap[index], _heap[indexToSwapWith]) = (_heap[indexToSwapWith], _heap[index]);
                index = indexToSwapWith;
                leftChildIndex = LeftChild(index);
                rightChildIndex = RightChild(index);
            }
        }
        
        private int LeftChild(int i) => 2*i + 1;
        private int RightChild(int i) => 2*i + 2;
        private int ParentIndex(int i) => (i - 1) / 2;
    }

    public class HeapElement(int value, int index) : IComparable<HeapElement>
    {
        public int Value { get; set; } = value;
        public int Index { get; set; } = index;
        public int CompareTo(HeapElement? other)
        {
            if (other == null) throw new NullReferenceException();
            var valueComparison = Value.CompareTo(other.Value);
            if (valueComparison != 0) return valueComparison;
            return Index.CompareTo(other.Index);
        }

        public static bool operator >(HeapElement a, HeapElement b) => a.CompareTo(b) > 0;
        public static bool operator <(HeapElement a, HeapElement b) => a.CompareTo(b) < 0;
        public static bool operator >=(HeapElement a, HeapElement b) => a.CompareTo(b) >= 0;
        public static bool operator <=(HeapElement a, HeapElement b) => a.CompareTo(b) <= 0;
    }
}

