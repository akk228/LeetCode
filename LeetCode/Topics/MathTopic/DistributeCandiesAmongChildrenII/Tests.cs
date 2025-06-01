using System.Collections.Generic;
using Xunit;

namespace LeetCode.Topics.MathTopic.DistributeCandiesAmongChildrenII;

public class Tests
{
    public static IEnumerable<object[]> TestData
    {
        get
        {
            // Example 1: n = 3, limit = 3, expected = 10
            yield return new object[] { 3, 3, 10L };
            // Example 2: n = 5, limit = 2, expected = 6
            yield return new object[] { 5, 2, 6L };
            // Example 3: n = 0, limit = 0, expected = 1 (all zero)
            yield return new object[] { 0, 0, 1L };
            // Example 4: n = 2, limit = 1, expected = 3
            yield return new object[] { 2, 1, 3L };
            // Example 5: n = 10, limit = 5, expected = 21
            yield return new object[] { 10, 5, 21L };
        }
    }

    private readonly IEnumerable<MySolution> _solutions = new MySolution[] { new MySolution() };

    [Theory]
    [MemberData(nameof(TestData))]
    public void ReturnsExpectedResult(int n, int limit, long expected)
    {
        foreach (var sol in _solutions)
        {
            var actual = sol.DistributeCandies(n, limit);
            Assert.Equal(expected, actual);
        }
    }
}
