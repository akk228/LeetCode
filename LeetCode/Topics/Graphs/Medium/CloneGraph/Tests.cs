#nullable disable
using System.Diagnostics.CodeAnalysis;

namespace LeetCode.Topics.Graphs.Medium.CloneGraph;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[]
            {
                new Node(1, new List<Node>
                {
                    new Node(2, new List<Node>()),
                    new Node(3, new List<Node>()),
                }),
                new Node(1, new List<Node>
                {
                    new Node(2, new List<Node>()),
                    new Node(3, new List<Node>()),
                })
            },
            new object[]
            {
                new Node(1, new List<Node>
                {
                    new Node(2, new List<Node>
                    {
                        new Node(3, new List<Node>()),
                    }),
                }),
                new Node(1, new List<Node>
                {
                    new Node(2, new List<Node>
                    {
                        new Node(3, new List<Node>()),
                    }),
                })
            },
            new object[]
            {
                null,
                null
            }
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new RecursiveDFS()
        // Add other implementations of ISolution here
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestCloneGraph(Node input, Node expected)
    {
        foreach (var solution in _solutions)
        {
            Node result = solution.CloneGraph(input);
            Assert.True(AreGraphsEqual(expected, result));
        }
    }

    private bool AreGraphsEqual(Node node1, Node node2)
    {
        if (node1 == null && node2 == null) return true;
        if (node1 == null || node2 == null) return false;
        if (node1.val != node2.val) return false;

        var visited = new HashSet<Node>();
        return DFS(node1, node2, visited);
    }

    private bool DFS(Node node1, Node node2, HashSet<Node> visited)
    {
        if (visited.Contains(node1)) return true;
        if (node1.neighbors.Count != node2.neighbors.Count) return false;

        visited.Add(node1);

        for (int i = 0; i < node1.neighbors.Count; i++)
        {
            if (!DFS(node1.neighbors[i], node2.neighbors[i], visited)) return false;
        }

        return true;
    }
}
