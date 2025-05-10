using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace LeetCode.Topics.Searching.Medium.FindFirstAndLastPositionOfElementInSortedArray;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { new int[] { 5, 7, 7, 8, 8, 10 }, 8, new[] { 3, 4 } },
            new object[] { new int[] { 5, 7, 7, 8, 8, 10 }, 6, new[] { -1, -1 } },
            new object[] { new int[] { }, 0, new[] { -1, -1 } },
            new object[] { new int[] { 1 }, 1, new[] { 0, 0 } },
            new object[] { new int[] { 2, 2 }, 2, new[] { 0, 1 } },
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new MySolution()
        // Add other implementations of ISolution here
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestSearchRange(int[] nums, int target, int[] expected)
    {
        foreach (var solution in _solutions)
        {
            int[] result = solution.SearchRange(nums, target);
            Assert.Equal(expected, result);
        }
    }
}
