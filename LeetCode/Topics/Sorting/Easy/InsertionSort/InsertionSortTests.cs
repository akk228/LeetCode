namespace LeetCode.Topics.Sorting.Easy.InsertionSort;

public class InsertionSortTests : SortingSpecifications
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void IsSorted(int[] nums)
    {
        InsertionSort.SortAscending(nums);
        Assert.True(TestHelper.IsOrderAscending(nums));
    }
}