using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace LeetCode.Topics.DynamicProgramming.Medium.CheckIfNumberIsASumOfPowersOfThree;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { 12, true },
            new object[] { 91, true },
            new object[] { 21, false }
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new MySolution(),
        new IterativeSolution()
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestCheckPowersOfThree(int n, bool expected)
    {
        foreach (var solution in _solutions)
        {
            bool result = solution.CheckPowersOfThree(n);
            Assert.Equal(expected, result);
        }
    }
}
