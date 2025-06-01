using System;

namespace LeetCode.Topics.Matrix.Medium.SnakesAndLeaders;

/// <summary>
/// it's incorrect solution, but it works if there are no loops in the board.
/// </summary>
public class DfsSolution : ISolution
{
    private int _size;
    private int _sizeSquare;

    public int SnakesAndLadders(int[][] board)
    {
        _size = board.Length;
        _sizeSquare = _size * _size;

        var moveCount = new int[_size, _size];

        for (var x = 0; x < _size; x++)
        {
            for (var y = 0; y < _size; y++)
            {
                moveCount[x, y] = Int32.MaxValue;
            }
        }

        Move(1, board, moveCount, 0);

        (int X, int Y) = GetCoordinates(_sizeSquare);

        var result = moveCount[X, Y];

        return result == Int32.MaxValue ? -1 : result;
    }

    // returns -1 if couldnt move there
    private void Move(int current, int[][] board, int[,] moveCountTable, int curentMoveCount)
    {
        (int x, int y) = GetCoordinates(current);

        if (curentMoveCount > moveCountTable[x, y])
        {
            return;
        }

        moveCountTable[x, y] = curentMoveCount;

        if (current == _sizeSquare)
        {
            return;
        }

        var source = current;
        // if snkae or lader
        while (board[x][y] != -1)
        {
            source = board[x][y];
            (x, y) = GetCoordinates(source);
            moveCountTable[x, y] = Math.Min(curentMoveCount, moveCountTable[x, y]);

            if (source == _sizeSquare)
            {
                return;
            }

            if (board[x][y] != -1)
            {
                curentMoveCount++;
            }
        }

        var end = Math.Min(source + 6, _sizeSquare);

        for (var next = source + 1; next <= end; next++)
        {
            Move(next, board, moveCountTable, curentMoveCount + 1);
        }
    }

    private (int X, int Y) GetCoordinates(int cell)
    {
        var x = (cell - 1) / _size;
        var delta = (cell - 1) % _size;
        var y = x % 2 == 0 ? delta : _size - delta - 1;
        return (_size - x - 1, y);
    }
}
