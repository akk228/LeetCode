namespace LeetCode.Topics.Matrix.Medium.CountUnguardedCellsInTheGrid;

public class Solution
{
    private const int X = 0;
    private const int Y = 1;
    private const int Guard = 1;
    private const int Wall = 2;
    private const int Guarded = 3;
    private const int Free = 0;

    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
        var grid = new int [m,n];

        foreach(var guard in guards) grid[guard[X], guard[Y]] = Guard;
        foreach(var wall in walls) grid[wall[X], wall[Y]] = Wall;

        // horizontal
        for(var i = 0; i < m; i++)
        {
            var isGuarded = false;
            for(var j = 0; j < n; j++) GridFill(grid, ref isGuarded, i, j);
            
            isGuarded = false;
            for(var j = n - 1; j >= 0; j--) GridFill(grid, ref isGuarded, i, j);
        }

        // vertical
        for(var i = 0; i < n; i++)
        {
            var isGuarded = false;
            for(var j = 0; j < m; j++) GridFill(grid, ref isGuarded, j, i);
            
            isGuarded = false;
            for(var j = m - 1; j >= 0; j--) GridFill(grid, ref isGuarded, j, i);
        }

        var unguardedCellsCount = 0;

        for(var i = 0; i < m; i++)
        for(var j = 0; j < n; j++)
            if(grid[i, j] == Free) unguardedCellsCount++;

        return unguardedCellsCount;
    }

    private void GridFill(int[,] grid, ref bool isGuarded, int i, int j)
    {
        switch(grid[i, j])
        {
            case Guard:
                isGuarded = true;
                break;
            case Wall:
                isGuarded = false;
                break;
            case Guarded:
                break;
            default:
                grid[i, j] = isGuarded ? Guarded : Free;
                break;
        }
    }
}