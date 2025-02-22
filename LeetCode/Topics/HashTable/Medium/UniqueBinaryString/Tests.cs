using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace LeetCode.Topics.HashTable.Medium.UniqueBinaryString;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { new string[] { "01", "10" }, "00" },
            new object[] { new string[] { "00", "01" }, "10" },
            new object[] { new string[] { "111", "011", "001" }, "000" }
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new Solution()
        // Add other implementations of ISolution here
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestFindDifferentBinaryString(string[] nums, string expected)
    {
        foreach (var solution in _solutions)
        {
            string result = solution.FindDifferentBinaryString(nums);
            Assert.Equal(expected, result);
        }
    }
}
