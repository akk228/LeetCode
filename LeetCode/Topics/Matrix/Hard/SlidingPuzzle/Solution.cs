namespace LeetCode.Topics.Matrix.Hard.SlidingPuzzle;
using System;
public class Solution
{
    private const string SolvedBoard = "123450";
    private readonly int[][] _moves = [
        [1,3],
        [0,2,4],
        [1,5],
        [0,4],
        [3,5,1],
        [2,4]
    ];
    
    public int SlidingPuzzle(int[][] board)
    {
        var lineBoard = TransformBoardToLine(board);
        var zeroLocation = Array.IndexOf(lineBoard, 0);
        var visitedBoardStates = new Dictionary<string, int>();
        GetPathLength(zeroLocation, lineBoard, string.Join("",lineBoard), visitedBoardStates, 0);
        
        return visitedBoardStates.GetValueOrDefault(SolvedBoard, -1);
    }
    private int[] TransformBoardToLine(int[][] board)
    {
        var line = new int[6];

        for (var i = 0; i < 3; i++)
        {
            line[i] = board[0][i];
            line[3 + i] = board[1][i];
        }

        return line;
    }
    private void GetPathLength(int zeroLocation, int[] board, string currentState, Dictionary<string, int> visitedBoardStates,int currentPathLength)
    {
        if (visitedBoardStates.TryGetValue(currentState, out int pathLengthToState) && currentPathLength >= pathLengthToState)
        {
            return;
        }

        if (!visitedBoardStates.TryAdd(currentState, currentPathLength))
        {
            visitedBoardStates[currentState] = currentPathLength;
        }
        
        foreach (var move in _moves[zeroLocation])
        {
            (board[move], board[zeroLocation]) = (board[zeroLocation], board[move]);
            GetPathLength(move, board, string.Join("",board), visitedBoardStates, currentPathLength + 1);
            (board[move], board[zeroLocation]) = (board[zeroLocation], board[move]);
        }
    }
}