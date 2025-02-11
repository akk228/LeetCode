namespace LeetCode.Topics.Matrix.Medium.MaximumMatrixSum;

/// <summary>
/// 1975. Maximum Matrix Sum
/// </summary>
public class Solution
{
    public long MaxMatrixSum(int[][] matrix)
    {
        var negativeCount = 0;
        var min = Int32.MaxValue;
        long sum = 0;

        for (var i = 0; i < matrix.Length; i++)
        {
            for(var j = 0; j < matrix[0].Length; j++)
            {
                if(matrix[i][j] < 0)
                {
                    negativeCount++;
                    matrix[i][j] *= -1;
                }

                if (matrix[i][j] < min)
                {
                    min = matrix[i][j];
                }

                sum += matrix[i][j];
            }   
        }

        return negativeCount % 2 == 0 ? sum : sum - 2*min;
    }
}