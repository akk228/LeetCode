using System.Collections.Generic;
using Xunit;

namespace LeetCode.Topics.Strings.Medium.BasicCalculatorII;

public class Tests
{
    public static IEnumerable<object[]> TestData
    {
        get
        {
            // Example 1: Simple addition
            yield return new object[] { "3+2+1", 6 };
            // Example 2: Addition and subtraction
            yield return new object[] { "3+2-1", 4 };
            // Example 3: Multiplication and division
            yield return new object[] { "3*2/2", 3 };
            // Example 4: Mixed operations
            yield return new object[] { "3+2*2", 7 };
            // Example 5: Mixed with spaces
            yield return new object[] { " 3 + 5 / 2 ", 5 };
            // Example 6: Negative result
            yield return new object[] { "1-2*3", -5 };
            // Example 7: Only one number
            yield return new object[] { "42", 42 };
        }
    }

    private readonly IEnumerable<ISolution> _solutions = new ISolution[] { new MySolution() };

    [Theory]
    [MemberData(nameof(TestData))]
    public void ReturnsExpectedResult(string s, int expected)
    {
        foreach (var sol in _solutions)
        {
            var actual = sol.Calculate(s);
            Assert.Equal(expected, actual);
        }
    }
}
