namespace LeetCode.Algos.Search.BinarySearch;

public class BinarySearchTests
{
    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { new int[] { 1, 3, 5, 7, 9 }, 5, 2 };
        yield return new object[] { new int[] { 1, 3, 5, 7, 9 }, 4, -1 };
        yield return new object[] { new int[] { 10 }, 10, 0 };
        yield return new object[] { new int[] { 10 }, 5, -1 };
    }

    public static IEnumerable<object[]> TestDataForFindLessOrEqual()
    {
        yield return new object[] { new int[] { 1, 3, 5, 7, 9 }, 6, 2 }; // 5 is the largest <= 6
        yield return new object[] { new int[] { 1, 3, 5, 7, 9 }, 10, 4 }; // 9 is the largest <= 10
        yield return new object[] { new int[] { 1, 3, 5, 7, 9 }, 0, -1 }; // no element <= 0
        yield return new object[] { new int[] { 10 }, 10, 0 }; // 10 is the largest <= 10
        yield return new object[] { new int[] { 10 }, 5, -1 }; // no element <= 5
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Find_Tests(int[] array, int target, int expected)
    {
        int result = BinarySearch<int>.Find(array, target);
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(TestDataForFindLessOrEqual))]
    public void FindLessOrEqual_Tests(int[] array, int target, int expected)
    {
        int result = BinarySearch<int>.FindLessOrEqual(array, target);
        Assert.Equal(expected, result);
    }
}
