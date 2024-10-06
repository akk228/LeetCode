namespace LeetCode.Topics.Graphs.Medium.WordSearch;

/// <summary>
/// 79. Word Search
/// </summary>
/// <remarks>
///     Beats 46.33% in runtime
///     Beats 48.32% in memory
/// </remarks>
public class Solution
{
    private readonly int[][] _shifts = [[0, 1], [0,-1], [1, 0], [-1, 0]];

    public bool Exist(char[][] board, string word) {
        var visitedCells = new bool[board.Length][];
        
        for (var row = 0; row < board.Length; row++)
        {
            visitedCells[row] = new bool[board[0].Length];
        }
        
        for(var row = 0; row < board.Length; row++){
            for(var col = 0; col < board[0].Length; col++)
            {
                if (board[row][col] != word[0]) continue;
                if(Traverse(board, row, col, word, 0, visitedCells)){
                    return true;
                }
            }    
        }

        return false;
    }

    private bool Traverse(char[][] board, int x, int y, string word, int currentPosition, bool[][] visitedCells){
        if(currentPosition == word.Length - 1 && word[currentPosition] == board[x][y]){
            return true;
        }

        if(word[currentPosition] != board[x][y]){
            return false;
        }

        visitedCells[x][y] = true;
        currentPosition++;

        var result = false;

        foreach(var shift in _shifts){
            var x_ = x + shift[0];
            var y_ = y + shift[1];

            if(x_ >= 0 && x_ < board.Length && y_ >=0 && y_ < board[0].Length && !visitedCells[x_][y_])
            {
                result |= Traverse(board, x_, y_, word, currentPosition, visitedCells);
            }
        }
        
        visitedCells[x][y] = false;

        return result;
    }
}