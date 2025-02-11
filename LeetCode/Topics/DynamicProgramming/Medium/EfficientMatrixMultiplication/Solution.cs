namespace LeetCode.Topics.DynamicProgramming.Medium.EfficientMatrixMultiplication;

public class Solution
{
    private const int RowCount = 0;
    private const int ColumnCount = 1;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrixDimensions">
    ///     Array of matrix dimension, where every subarray contains to elements.
    ///     For each i : nums[i] = [RowsCount, ColumnCount]</param>
    /// <param name="multiplicationResults">
    ///     Every element of this matrix m[i,j] here shows what is the minimum number of operations
    ///     to be performed to multiply matrix from i to j.
    ///     For this matrix only elements such that i &lt;= j matter
    /// </param>
    /// <param name="mostEfficientPartitioning">
    ///     
    /// </param>
    public static void CalculateEffectiveMatrixMultiplication(
        int[][] matrixDimensions,
        out long[,] multiplicationResults,
        out long[,] mostEfficientPartitioning)
    {
        var matrixCount = matrixDimensions.Length;
        
        multiplicationResults = new long[matrixCount, matrixCount];
        mostEfficientPartitioning = new long[matrixCount, matrixCount];
        
        // Matrix should be initialized such that main diagonal contains only zeros, which is the case by default, because default int is 0
        
        // we compute matrix by moving up the main diagonal
        for (var diagonalLength = matrixCount - 1; diagonalLength > 0 ; diagonalLength--)
        {
            for (var i = 0; i < diagonalLength; i++)
            {
                var j = matrixCount - diagonalLength + i;
                
                multiplicationResults[i,j] = Int64.MaxValue;
                
                for (var k = i; k < j; k++)
                {
                    var result = 
                        multiplicationResults[i, k] + 
                        multiplicationResults[k + 1, j] +
                        matrixDimensions[i][RowCount]*matrixDimensions[k][ColumnCount]*matrixDimensions[j][ColumnCount];
                    
                    if (multiplicationResults[i, j] <= result) continue;
                    
                    multiplicationResults[i, j] = result;
                    mostEfficientPartitioning[i, j] = k;
                }
            }
        }
    }
}