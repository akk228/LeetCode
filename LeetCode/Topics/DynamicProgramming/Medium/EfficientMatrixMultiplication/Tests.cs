namespace LeetCode.Topics.DynamicProgramming.Medium.EfficientMatrixMultiplication;

public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[]{ (int[][])[[1,2]], 0},
            new object[]{ (int[][])[[1,2],[2,1]], 2},
            new object[]{ (int[][])[[1,2],[2,3]], 6},
            new object[]{ (int[][])[[1,2],[2,2],[2,1]], 6},
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public void CorrectMinimumNumberOfOperations(int[][] dimensionsOfMatrices, int expectedMinNumberOfOperations)
    {
        Solution.CalculateEffectiveMatrixMultiplication(dimensionsOfMatrices, out long[,] result, out long[,] splitting);
        var actualMinNumberOfOperations = result[0, dimensionsOfMatrices.Length - 1];
        Assert.Equal(expectedMinNumberOfOperations, actualMinNumberOfOperations);
    }
}