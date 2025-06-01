namespace LeetCode.Topics.Matrix.Medium.SnakesAndLeaders;

public class GraphSolution : ISolution
{
    public int[] Parents { get; private set; } = System.Array.Empty<int>();
    public int SnakesAndLadders(int[][] board)
    {
        var size = board.Length;
        var sizeSquare = size * size;

        var visited = new int[sizeSquare + 1];
        Parents = new int[sizeSquare + 1];

        Parents[1] = -1;

        var bfsQueue = new Queue<(int Cell, int Distance)>();
        (int Cell, int Distance) current = (1, 0);
        bfsQueue.Enqueue(current);

        while (bfsQueue.Count > 0)
        {
            current = bfsQueue.Dequeue();

            var end = Math.Min(current.Cell + 6, sizeSquare);
            var newDistance = current.Distance + 1;

            for (var next = end; next >= current.Cell + 1; next--)
            {
                (int X, int Y) = GetCoordinates(next, size);
                var target = board[X][Y] != -1 ? board[X][Y] : next;

                if (visited[target] > 0)
                {
                    continue;
                }

                visited[target] = newDistance;
                Parents[target] = current.Cell;


                if (target == sizeSquare)
                {
                    return newDistance;
                }

                bfsQueue.Enqueue((target, newDistance));
            }
        }

        var last = visited[sizeSquare];

        return last > 0 || sizeSquare == 1 ? last : -1;
    }

    private (int X, int Y) GetCoordinates(int cell, int size)
    {
        var x = (cell - 1) / size;
        var delta = (cell - 1)  % size;
        var y = x % 2 == 0 ? delta : size - delta - 1; 
        return (size - x - 1, y);
    }
}
