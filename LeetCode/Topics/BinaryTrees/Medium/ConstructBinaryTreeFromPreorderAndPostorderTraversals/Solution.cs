namespace LeetCode.Topics.BinaryTrees.Medium.ConstructBinaryTreeFromPreorderAndPostorderTraversals;

#nullable disable
public class Solution : ISolution
{
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
    {
        var preIndex = 0;
        var postIndex = 0;
        return Construct(preorder, postorder, ref preIndex, ref postIndex);
    }

    private TreeNode Construct(int[] preorder, int[] postorder, ref int preIndex, ref int postIndex)
    {
        var root = new TreeNode(preorder[preIndex++]);
        if (root.val != postorder[postIndex])
        {
            root.left = Construct(preorder, postorder, ref preIndex, ref postIndex);
        }
        if (root.val != postorder[postIndex])
        {
            root.right = Construct(preorder, postorder, ref preIndex, ref postIndex);
        }
        postIndex++;
        return root;
    }
}
#nullable disable

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left = null, TreeNode right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}