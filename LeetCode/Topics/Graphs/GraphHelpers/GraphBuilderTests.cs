namespace LeetCode.Topics.Graphs.GraphHelpers;

public class GraphBuilderTests
{
    private readonly GraphBuilder _graphBuilder = new GraphBuilder();
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]{ (int[][])[[0, 1],[1, 2]] , 3}
        };
    
    [Theory]
    [MemberData(nameof(Data))]
    public void BuildsCorrectGraph(int[][] edges, int vertices)
    {
        var graph = _graphBuilder.BuildUndirectedUnweightedGraph(edges, vertices);
        Assert.True(true);
    }
}