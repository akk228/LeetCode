using System;

namespace LeetCode.Topics.DynamicProgramming.Medium.UiquePathsII;

public class MySolution : ISolution
{
    private const int Obstacle = 1;
    private const int Space = 0;

    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        var height = obstacleGrid.Length;
        var width = obstacleGrid[0].Length;
        var pathCounts = new int[height, width];
        var visited = new bool[height, width];
        var cells = new Queue<(int X, int Y)>();

        if (obstacleGrid[0][0] == Obstacle)
        {
            return 0;
        }

        pathCounts[0, 0] = 1;
        cells.Enqueue((0, 0));

        while (cells.Count > 0)
        {
            var cell = cells.Dequeue();

            if (cell.X > 0 && obstacleGrid[cell.X - 1][cell.Y] != Obstacle)
            {
                pathCounts[cell.X, cell.Y] += pathCounts[cell.X - 1, cell.Y];
            }

            if (cell.Y > 0 && obstacleGrid[cell.X][cell.Y - 1] != Obstacle)
            {
                pathCounts[cell.X, cell.Y] += pathCounts[cell.X, cell.Y - 1];
            }
            
            AddNext((cell.X + 1, cell.Y), obstacleGrid, cells, visited);
            AddNext((cell.X, cell.Y + 1), obstacleGrid, cells, visited);
        }

        return pathCounts[height - 1, width - 1];
    }

    private void AddNext((int X, int Y) nextCell, int[][] obstacleGrid, Queue<(int X, int Y)> cells, bool[,] visited)
    {
        if (nextCell.X < obstacleGrid.Length &&
            nextCell.Y < obstacleGrid[0].Length &&
            obstacleGrid[nextCell.X][nextCell.Y] != Obstacle &&
            !visited[nextCell.X, nextCell.Y])
        {
            cells.Enqueue(nextCell);
            visited[nextCell.X, nextCell.Y] = true;
        }
    }
}
