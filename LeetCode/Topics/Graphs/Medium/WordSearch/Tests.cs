namespace LeetCode.Topics.Graphs.Medium.WordSearch;

public class Tests
{
    private readonly Solution _solution = new ();

    [Theory]
    [MemberData(nameof(TestData))]
    public void WordSearchTest(char[][] board, string word, bool expectedExists)
    {
        
        var actualExists = _solution.Exist(board, word);
        
        Assert.Equal(expectedExists, actualExists);
    }
    
    public static IEnumerable<object[]> TestData => new List<object[]>()
    {
        new object[]
        {
            new [] { new[] {'A','B','C','E'}, ['S','F','C','S'], ['A','D','E','E'] },
            "ABCB",
            false
        },
        new object[]
        {
            new[]{new []{'A','B','C','E'}, ['S','F','C','S'], ['A','D','E','E']},
            "ABCCED",
            true
        },
        new object[]
        {
            new[]{new []{'A','B','C','E'}, ['S','F','C','S'], ['A','D','E','E']},
            "SEE",
            true
        }
    };
}