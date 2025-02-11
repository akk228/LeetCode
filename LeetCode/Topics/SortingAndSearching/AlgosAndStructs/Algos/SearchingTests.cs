namespace LeetCode.Topics.SortingAndSearching.AlgosAndStructs.Algos;

public class SearchingTests
{
    public static IEnumerable<object[]> SearchTestData => new List<object[]>()
    {
        new object[] { (int[])[1,3] ,3, 3},
        new object[] { (int[])[1,3] ,2, 3},
        new object[] { (int[])[1,3,5,7], 5, 5},
        new object[] { (int[])[1,3,5,7], 4, 5},
    };

    [Theory]
    [MemberData(nameof(SearchTestData))]
    public void FindsCorrectLowerBound(int[] items, int val, int indexOfExpectedItem)
    {
        var index = BinarySearch.FindUpperBound(items, 0, items.Length - 1, val);
        
        Assert.Equal(indexOfExpectedItem, items[index]);
    }
    
    public static IEnumerable<object[]> SearchTestOutOfBoundsData => new List<object[]>()
    {
        new object[] { (int[])[1,3] ,0, -1},
        new object[] { (int[])[1,3] ,4, -1},
        new object[] { (int[])[1,3,5,7], -1, -1},
        new object[] { (int[])[1,3,5,7], 9, -1},
    };

    [Theory]
    [MemberData(nameof(SearchTestOutOfBoundsData))]
    public void FindsCorrectIndexForOutOfBoundsValue(int[] items, int val, int expectedIndex)
    {
        var index = BinarySearch.FindUpperBound(items, 0, items.Length - 1, val);

        Assert.Equal(expectedIndex, index);
    }
}