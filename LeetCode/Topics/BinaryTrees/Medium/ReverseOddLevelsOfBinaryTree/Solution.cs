namespace LeetCode.Topics.BinaryTrees.Medium.ReverseOddLevelsOfBinaryTree;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode ReverseOddLevels(TreeNode root) {
        var nodes = new List<TreeNode>();
        nodes.Add(root);
        var isOdd = false;

        while (nodes.Count > 0)
        {
            if (isOdd)
                for (var i = 0; i < nodes.Count / 2; i++)
                    (nodes[i].Val, nodes[nodes.Count - 1 - i].Val) = (nodes[nodes.Count - 1 - i].Val, nodes[i].Val);
            
            isOdd = !isOdd;

            var newNodes = new List<TreeNode>();
            
            if (nodes[0].Left is null) break;
            
            nodes.ForEach(node =>
            {
                newNodes.Add(node.Left);
                newNodes.Add(node.Right);
            });

            nodes = newNodes;
        }

        return root;
    }
}