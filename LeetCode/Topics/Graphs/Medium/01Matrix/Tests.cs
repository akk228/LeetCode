namespace LeetCode.Topics.Graphs.Medium._01Matrix;

public class Tests
{
    private readonly ISolution _solution = new Solution2();
    
    [Fact]
    public void GotCorrectDistances()
    {
        int[][] expected = [[0], [0], [0], [0], [0]]; // [[0,0,0],[0,1,0],[1,2,1]];
        int[][] matrix = [[0], [0], [0], [0], [0]]; // [[0,0,0],[0,1,0],[1,1,1]];

        var actual = _solution.UpdateMatrix(matrix);
        CheckResult(actual, expected);
    }

    private void CheckResult(int[][] actual, int[][] expected)
    {
        for (int i = 0; i < expected.Length; ++i)
        {
            for (int j = 0; j < expected[i].Length; ++j)
            {
                if(expected[i][j] != actual[i][j]) Assert.True(false);
            }
        }
        
        Assert.True(true);
    }
}