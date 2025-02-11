namespace LeetCode.Topics.SortingAndSearching.AlgosAndStructs.Algos;

public class SortingTests
{
    public static IEnumerable<object[]> SortTestData => new List<object[]>()
    {
        new object[] { (int[])[1] },
        new object[] { (int[])[1,1] },
        new object[] { (int[])[1,2] },
        new object[] { (int[])[2,1] },
        new object[] { (int[])[1,2,3] },
        new object[] { (int[])[1,1,1] },
        new object[] { (int[])[1,1,1] },
        new object[] { (int[])[2,2,1] },
        new object[] { (int[])[2,2,3] },
        new object[] { (int[])[1,2,3] },
        new object[] { (int[])[4,3,3,2,8] },
    };

    [Theory]
    [MemberData(nameof(SortTestData))]
    public void QuickSortPerformsCorrectSorting(int[] items)
    {
        QuickSort.Sort(items);
        
        Assert.True(IsSorted(items));
    }
    
    private static bool IsSorted<T>(T[] items) where T : IComparable<T>
    {
        var result = true;
        
        for (int i = 1; i < items.Length; i++)
        {
            if (items[i - 1].CompareTo(items[i]) > 0)
            {
                result = false;
                break;
            }
        }

        return result;
    }
}