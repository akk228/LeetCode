namespace LeetCode.Topics.Graphs.Medium.WordSearch;

/// <summary>
/// 79. Word Search
/// </summary>
/// <remarks>
///     Beats 46.33% in runtime
///     Beats 91.51% in memory
/// </remarks>
public class Solution
{
    private readonly int[][] _shifts = [[0, 1], [0,-1], [1, 0], [-1, 0]];
    private readonly char Null = '\0';
    
    public bool Exist(char[][] board, string word) {
        for(var row = 0; row < board.Length; row++){
            for(var col = 0; col < board[0].Length; col++)
            {
                if (board[row][col] != word[0]) continue;
                if(Traverse(board, row, col, word, 0)){
                    return true;
                }
            }    
        }

        return false;
    }

    private bool Traverse(char[][] board, int x, int y, string word, int currentPosition){
        if(currentPosition == word.Length - 1 && word[currentPosition] == board[x][y]){
            return true;
        }

        if(word[currentPosition] != board[x][y]){
            return false;
        }

        var currentChar = board[x][y];
        
        board[x][y] = Null; // use unicode null to backtrack visited cells
        currentPosition++;

        var result = false;

        foreach(var shift in _shifts){
            var x_ = x + shift[0];
            var y_ = y + shift[1];

            if(x_ >= 0 && x_ < board.Length && y_ >=0 && y_ < board[0].Length && board[x_][y_] != Null)
            {
                result |= Traverse(board, x_, y_, word, currentPosition);
            }
        }
        
        board[x][y] = currentChar;

        return result;
    }
}