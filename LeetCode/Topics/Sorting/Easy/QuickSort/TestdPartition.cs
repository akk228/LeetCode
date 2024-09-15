namespace LeetCode.Topics.Sorting.Easy.QuickSort;

public class TestdPartition
{
    private Solution _solution = new Solution();
    public static IEnumerable<object[]> Data =>
        new List<object[]>()
        {
            new object[]{ new []{1,2,3}, 1},
            new object[]{ new []{1,2,3}, 2},
            new object[]{ new []{1,1,2,5}, 1},
            new object[]{ new []{3,3,2,1}, 1},
            new object[]{ new []{3,3,2,1}, 0}
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void PartitionedCorrectly(int[] arr, int pivot)
    {
        var pivotElement = arr[pivot];
        var pivotIndex = _solution.Partition(arr, 0, arr.Length - 1, pivot);
        
        Assert.Equal(pivotElement, arr[pivotIndex]);
        
    }

    private void CheckPartitioning(int[] arr, int pivotIndex)
    {
        for (int i = 0; i <= pivotIndex; i++)
        {
            if(arr[i] > arr[pivotIndex]) Assert.Fail($"Element {arr[i]} at position {i} is greater than pivot {arr[pivotIndex]} at pivot index {pivotIndex}");
        }

        for (int i = pivotIndex + 1; i < arr.Length; i++)
        {
            if(arr[i] <= arr[pivotIndex]) Assert.Fail($"Element {arr[i]} at position {i} is less or equal than pivot {arr[pivotIndex]} at pivot index {pivotIndex}");
        }
        
        Assert.True(true, "");
    }
}