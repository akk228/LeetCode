using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace LeetCode.Topics.BinaryTrees.Hard.RecoverTreeFromPreorderTraversal;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { "1-2--3--4-5--6--7", new TreeNode(1, new TreeNode(2, new TreeNode(3), new TreeNode(4)), new TreeNode(5, new TreeNode(6), new TreeNode(7))) },
            // new object[] { "1-2--3---4-5--6---7", new TreeNode(1, new TreeNode(2, new TreeNode(3, null, new TreeNode(4))), new TreeNode(5, new TreeNode(6, null, new TreeNode(7)))) },
            new object[] { "1-401--349---90--88", new TreeNode(1, new TreeNode(401, new TreeNode(349, new TreeNode(90)), new TreeNode(88))) }
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        // new Solution()
        new MySolution()
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestRecoverFromPreorder(string traversal, TreeNode expected)
    {
        foreach (var solution in _solutions)
        {
            TreeNode result = solution.RecoverFromPreorder(traversal);
            Assert.True(AreEqual(result, expected));
        }
    }

    private bool AreEqual(TreeNode a, TreeNode b)
    {
        if (a == null && b == null) return true;
        if (a == null || b == null) return false;
        return a.val == b.val && AreEqual(a.left, b.left) && AreEqual(a.right, b.right);
    }
}
