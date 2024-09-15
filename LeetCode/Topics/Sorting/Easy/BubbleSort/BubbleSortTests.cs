namespace LeetCode.Topics.Sorting.Easy.BubbleSort;

public class BubbleSortTests : SortingSpecifications
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void IsSorted(int[] nums)
    {
        BubbleSort.SortAscending(nums);
        Assert.True(TestHelper.IsOrderAscending(nums));
    }
}