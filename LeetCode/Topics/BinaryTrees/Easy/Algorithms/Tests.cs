using LeetCode.Topics.BinaryTrees.Easy.Algorithms.Traversals;

namespace LeetCode.Topics.BinaryTrees.Easy.Algorithms;

public class Tests
{
    [Fact]
    public void TraversalTest()
    {
        var tree = new TreeNode(1);
        tree.Left = new TreeNode(2);
        tree.Right = new TreeNode(3);
        tree.Left.Left = new TreeNode(4);
        tree.Left.Right = new TreeNode(5);
        tree.Right.Left = new TreeNode(6);
        tree.Right.Right = new TreeNode(7);

        var actualTraversal = new List<TreeNode>();
        var expectedTraversal = new[] { 4, 5, 2, 6, 7, 3, 1 };
        
        BinaryTreePostOrder.Traverse(tree, actualTraversal);
        
        
        Assert.True(actualTraversal.Select(x => x.Val).SequenceEqual(expectedTraversal));
        
        // Console.WriteLine(string.Join(" -    > ",actualTraversal.Select(x => x.Val)));
    }
}