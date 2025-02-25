using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace LeetCode.Topics.Array.Medium.NumberOfSubarraysWithOddSum;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { new int[] { 1, 3, 5 }, 4 },
            new object[] { new int[] { 2, 4, 6 }, 0 },
            new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7 }, 16 }
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new MySolution()
        // Add other implementations of ISolution here
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestNumOfSubarrays(int[] nums, int expected)
    {
        foreach (var solution in _solutions)
        {
            int result = solution.NumOfSubarrays(nums);
            Assert.Equal(expected, result);
        }
    }
}
