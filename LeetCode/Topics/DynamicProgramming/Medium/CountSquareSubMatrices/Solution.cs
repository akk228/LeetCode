namespace LeetCode.Topics.DynamicProgramming.Medium.CountSquareSubMatrices;

public class Solution {
    public int CountSquares(int[][] matrix) {
        int count = 0;
        for(int i = 0; i < matrix.Length; i++){
            for(int j = 0; j < matrix[0].Length; j++){
                CountSquares(matrix, i, j, ref count);
            }
        }

        return count;
    }

    private void CountSquares(int[][] matrix,int x0, int y0, ref int count, int dimension = 1){
        if(x0 + dimension > matrix.Length || y0 + dimension > matrix[0].Length){
            return;
        }

        for(int x = x0; x < x0 + dimension; x++){
            if(matrix[x][y0 + dimension - 1] != 1){
                return;
            }
        }

        for(int y = y0; y < y0 + dimension; y++){
            if(matrix[x0 + dimension - 1][y] != 1){
                return;
            }
        }

        count++;
        CountSquares(matrix, x0, y0, ref count, dimension + 1);      
    }
}