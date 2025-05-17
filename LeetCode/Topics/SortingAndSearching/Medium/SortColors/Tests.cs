using System.Collections.Generic;
using Xunit;

namespace LeetCode.Topics.SortingAndSearching.Medium.SortColors;

public class Tests
{
    public static IEnumerable<object[]> Data
    {
        get
        {
            yield return [ new[] { 2, 0, 2, 1, 1, 0 }, new[] { 0, 0, 1, 1, 2, 2 } ];
            yield return [ new[] { 2, 0, 1 }, new[] { 0, 1, 2 } ];
            yield return [ new[] { 0 }, new[] { 0 } ];
            yield return [ new[] { 1 }, new[] { 1 } ];
            yield return [ new[] { 2 }, new[] { 2 } ];
            yield return [ new[] { 0, 0, 0 }, new[] { 0, 0, 0 } ];
            yield return [ new[] { 1, 1, 1 }, new[] { 1, 1, 1 } ];
            yield return [ new[] { 2, 2, 2 }, new[] { 2, 2, 2 } ];
            yield return [ new int[0], new int[0] ];
        }
    }

    private readonly ISolution solution = new MySolution();

    [Theory]
    [MemberData(nameof(Data))]
    public void SortColors_SortsCorrectly(int[] input, int[] expected)
    {
        solution.SortColors(input);
        Assert.Equal(expected, input);
    }
}
