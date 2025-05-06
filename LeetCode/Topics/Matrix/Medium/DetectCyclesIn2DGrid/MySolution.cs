using System;

namespace LeetCode.Topics.Matrix.Medium.DetectCyclesIn2DGrid;

/// <summary>
/// Beats 83 % time, and 55% in memory
/// </summary>
public class MySolution : ISolution
{
    public bool ContainsCycle(char[][] grid)
    {
        var visited = new bool[grid.Length, grid[0].Length];

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[0].Length; j++)
            {
                if (!visited[i, j] && TryGetCycle((i, j), (i, j), grid, visited))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool TryGetCycle((int X, int Y) start, (int X, int Y) parent, char[][] grid, bool[,] visited)
    {
        if (visited[start.X, start.Y])
        {
            return true;
        }

        visited[start.X, start.Y] = true;

        (int X, int Y) next = (start.X - 1, start.Y);
        // go up
        if (next.X >= 0 && // dont overflow
            grid[start.X][start.Y] == grid[next.X][next.Y] && // can go up
            next != parent && // not the parent
            TryGetCycle(next, start, grid, visited))
        {
            return true;
        }

        next = (start.X + 1, start.Y);
        // go down
        if (next.X < grid.Length && // dont overflow
            grid[start.X][start.Y] == grid[next.X][next.Y] && // can go up
            next != parent && // not the parent
            TryGetCycle(next, start, grid, visited))
        {
            return true;
        }

        next = (start.X, start.Y - 1);
        // go left
        if (next.Y >= 0 && // dont overflow
            grid[start.X][start.Y] == grid[next.X][next.Y] && // can go up
            next != parent && // not the parent
            TryGetCycle(next, start, grid, visited))
        {
            return true;
        }

        next = (start.X, start.Y + 1);
        // go left
        if (next.Y < grid[0].Length && // dont overflow
            grid[start.X][start.Y] == grid[next.X][next.Y] && // can go up
            next != parent && // not the parent
            TryGetCycle(next, start, grid, visited))
        {
            return true;
        }

        return false;
    }
}
