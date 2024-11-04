namespace LeetCode.Topics.DynamicProgramming.Medium.MaximumNumberOfMovesinGrid;


public class Solution
{
    private readonly int[][] _directions = {
        [1, 1],
        [-1, 1],
        [0, 1]
    };
    
    public int MaxMoves(int[][] grid) {
        var maxPath = 0;
        var visited = new bool[grid.Length][];
        
        for (var row = 0; row < grid.Length; row++)
        {
            visited[row] = new bool[grid[0].Length];
        }
        
        for(var i = 0; i < grid.Length; i++){
            var path = FindMaxPath(grid, i, 0, 0, visited);
            
            if (path == grid[0].Length - 1)
            {
                return grid[0].Length - 1;
            }

            if (path > maxPath)
            {
                maxPath = path;
            }
        }

        return maxPath;
    }

    private int FindMaxPath(int[][] grid, int x0, int y0, int currentPath, bool[][] visited)
    {
        var maxPath = currentPath;
        
        foreach(var direction in _directions){
            var x = x0 + direction[0];
            var y = y0 + direction[1];

            if (x < 0 ||
                x >= grid.Length ||
                y >= grid[0].Length ||
                grid[x][y] <= grid[x0][y0] ||
                visited[x][y])
            {
                continue;
            }
            
            visited[x][y] = true;
            
            var result = FindMaxPath(grid, x, y, currentPath + 1, visited);
            
            if (result == grid[0].Length - 1)
            {
                return grid[0].Length - 1;
            }

            if (result > maxPath)
            {
                maxPath = result;
            }
        }
        return maxPath;
    }
}