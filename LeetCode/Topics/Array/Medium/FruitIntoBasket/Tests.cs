using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace LeetCode.Topics.Array.Medium.FruitIntoBasket;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { new int[] { 1, 2, 1 }, 3 },
            new object[] { new int[] { 0, 1, 2, 2 }, 3 },
            new object[] { new int[] { 1, 2, 3, 2, 2 }, 4 },
            new object[] { new int[] { 3, 3, 3, 3, 3 }, 5 },
            new object[] { new int[] { 1, 2, 1, 2, 3, 4 }, 4 },
            new object[] { new int[] { 1 }, 1 },
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new MySolution()
        // Add other implementations of ISolution here
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestTotalFruit(int[] fruits, int expected)
    {
        foreach (var solution in _solutions)
        {
            int result = solution.TotalFruit(fruits);
            Assert.Equal(expected, result);
        }
    }
}
