using System.Diagnostics.CodeAnalysis;

namespace Studying.LeetCode.Topics.Heap.Medium.MaxSumOfPairWithEqualSumOfDigits;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { new int[] { 51, 71, 17, 42 }, 93 },
            new object[] { new int[] { 42, 33, 60 }, 102 },
            new object[] { new int[] { 51, 32, 43 }, -1 }
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new PriorityQueueSolution(),
        new StoreMaxValueSolution()
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestMaximumSum(int[] nums, int expected)
    {
        foreach (var solution in _solutions)
        {
            int result = solution.MaximumSum(nums);
            Assert.Equal(expected, result);
        }
    }
}
