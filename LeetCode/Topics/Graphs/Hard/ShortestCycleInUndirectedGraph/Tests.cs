using System.Diagnostics.CodeAnalysis;

namespace Studying.LeetCode.Topics.Graphs.Hard.ShortestCycleInUndirectedGraph;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { (int[][])[[0,1],[1,2],[2,0],[3,4],[4,5],[5,6],[6,3]], 7, 3 },
            new object[] { (int[][])[[0,1],[1,2],[2,3],[3,4],[4,5],[0,7],[0,6],[5,7],[5,6]], 8, 4 },
            new object[] { (int[][])[[0,1],[1,2],[2,0],[0,3],[3,4],[4,5],[6,7],[7,8],[8,9],[9,10],[10,11],[11,12],[12,0],[2,7],[2,4],[1,8],[1,11]]
, 13, 3 },
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new Solution()
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestShortestCycle(int[][] edges, int V, int expected)
    {
        foreach (var solution in _solutions)
        {
            int result = solution.FindShortestCycle(V, edges);
            Assert.Equal(expected, result);
        }
    }
}
