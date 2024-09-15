namespace LeetCode.Topics.Graphs.Easy.CycleInUndirectedGraph;

public class Tests
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>()
        {
            new object[]{ Graph1() , false}
        };

    public static List<int>[] Graph1()
    {
        int vertices = 4;
        var graph = new List<int>[4];
        graph[0] = (new int[]{1}).ToList();
        graph[1] = (new int[]{0,2,3}).ToList();
        graph[2] = (new int[]{1}).ToList();
        graph[3] = (new int[]{1}).ToList();
        return graph;
    }

    [Theory]
    [InlineData( false)]
    public void DetectCycle(  bool isCycle)
    {
        var graph = Graph1();
        var solution = new Solution();

        var result = solution.isCycle(graph.Length, graph);
        
        Assert.Equal(result, isCycle);
    }
}