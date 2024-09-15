namespace LeetCode.Topics.Sorting.Easy.SelectionSort;

public class SelectionSortTests : SortingSpecifications
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void IsSorted(int[] nums)
    {
        SelectionSort.Sort(nums);
        Assert.True(TestHelper.IsOrderAscending(nums));
    }
}