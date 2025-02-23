using System.Diagnostics.CodeAnalysis;

namespace LeetCode.Topics.BinaryTrees.Medium.ConstructBinaryTreeFromPreorderAndPostorderTraversals;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { new int[] { 1, 2, 4, 5, 3, 6, 7 }, new int[] { 4, 5, 2, 6, 7, 3, 1 }, new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3, new TreeNode(6), new TreeNode(7))) },
            new object[] { new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 }, new TreeNode(1, new TreeNode(2, new TreeNode(3))) }
        };

    private readonly IEnumerable<ISolution> _solutions = new List<ISolution>
    {
        new MySolution()
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestConstructFromPrePost(int[] preorder, int[] postorder, TreeNode expected)
    {
        foreach (var solution in _solutions)
        {
            TreeNode result = solution.ConstructFromPrePost(preorder, postorder);
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
