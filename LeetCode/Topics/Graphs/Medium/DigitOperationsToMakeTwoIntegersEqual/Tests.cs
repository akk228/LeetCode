namespace LeetCode.Topics.Graphs.Medium.DigitOperationsToMakeTwoIntegersEqual;

public class Tests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>()
    {
        new object[]{ 10, 12, 85},
        new object[]{ 4, 8, -1},
        new object[]{17, 72, -1},
        new object[]{ 36, 50, 353},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void RunTest(int num1, int num2, int expectedCost)
    {
        var actualCost = new Solution().MinOperations(num1, num2);
        
        Assert.Equal(expectedCost, actualCost);
    }
}