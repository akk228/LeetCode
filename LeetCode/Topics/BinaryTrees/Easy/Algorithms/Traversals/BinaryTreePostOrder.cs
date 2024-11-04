namespace LeetCode.Topics.BinaryTrees.Easy.Algorithms.Traversals;

public static class BinaryTreePostOrder
{
    public static void Traverse(TreeNode root, List<TreeNode> traversal)
    {
        if (root.Left != null)
        {
            Traverse(root.Left, traversal);
        }

        if (root.Right != null)
        {
            Traverse(root.Right, traversal);
        }

        if (traversal != null)
        {
            traversal.Add(root);
        }
        else
        {
            Console.Write(root.Val + " ");
        }
    }
}