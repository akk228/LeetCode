using System.Diagnostics.CodeAnalysis;

namespace LeetCode.Topics.Heap.Medium.MinimumOperationsToExceedThresholdValueII;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { new int[] {2,11,10,1,3}, 10, 2 },
            new object[] { new int[] {1,1,2,4,9}, 20, 4 },
            new object[] { new int[] {999999999,999999999,999999999}, 1000000000, 2 }
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new Solution()
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestMinOperations(int[] nums, int threshold, int expected)
    {
        foreach (var solution in _solutions)
        {
            int result = solution.MinOperations(nums, threshold);
            Assert.Equal(expected, result);
        }
    }
}
