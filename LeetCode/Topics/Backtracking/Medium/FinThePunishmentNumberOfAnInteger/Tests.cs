using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace LeetCode.Topics.Backtracking.Medium.FinThePunishmentNumberOfAnInteger;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { 10, 182 },
            new object[] { 37, 1478 },
            new object[] { 1, 1 }
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new BruteforceSolution(),
        new OptimalSolution()
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestPunishmentNumber(int n, int expected)
    {
        foreach (var solution in _solutions)
        {
            int result = solution.PunishmentNumber(n);
            Assert.Equal(expected, result);
        }
    }
}
