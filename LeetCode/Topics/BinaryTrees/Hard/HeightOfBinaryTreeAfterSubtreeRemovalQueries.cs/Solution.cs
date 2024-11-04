namespace LeetCode.Topics.BinaryTrees.Hard;

/// <summary>
/// 2458. Height of Binary Tree After Subtree Removal Queries
/// </summary>
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
    public int[] TreeQueries(TreeNode root, int[] queries) {
        int currentMaxHeight = 0;
        var maxHeightAfterRemoval = new Dictionary<int, int>();
        
        TraverseLeftToRight(root, 0, ref currentMaxHeight, maxHeightAfterRemoval);
        
        currentMaxHeight = 0; // Reset for the second traversal
        
        TraverseRightToLeft(root, 0, ref currentMaxHeight, maxHeightAfterRemoval);

        // Process queries and build the result array
       
        for (int i = 0; i < queries.Length; i++) {
            queries[i] = maxHeightAfterRemoval[queries[i]];
        }

        return queries;
    }

    private void TraverseLeftToRight(TreeNode node, int currentHeight, ref int currentMaxHeight, Dictionary<int, int> maxHeightAfterRemoval) {
        if (node == null) return;

        // Store the maximum height if this node were removed
        maxHeightAfterRemoval.Add(node.val, currentMaxHeight);

        // Update the current maximum height
        currentMaxHeight = Math.Max(currentMaxHeight, currentHeight);

        // Traverse left subtree first, then right
        TraverseLeftToRight(node.left, currentHeight + 1, ref currentMaxHeight, maxHeightAfterRemoval);
        TraverseLeftToRight(node.right, currentHeight + 1, ref currentMaxHeight, maxHeightAfterRemoval);
    }

    private void TraverseRightToLeft(TreeNode node, int currentHeight, ref int currentMaxHeight, Dictionary<int, int> maxHeightAfterRemoval) {
        if (node == null) return;

        // Update the maximum height if this node were removed
        // do not check existence here, because it must exist
        maxHeightAfterRemoval[node.val] = Math.Max(maxHeightAfterRemoval[node.val], currentMaxHeight);

        // Update the current maximum height
        currentMaxHeight = Math.Max(currentHeight, currentMaxHeight);

        // Traverse right subtree first, then left
        TraverseRightToLeft(node.right, currentHeight + 1, ref currentMaxHeight, maxHeightAfterRemoval);
        TraverseRightToLeft(node.left, currentHeight + 1, ref currentMaxHeight, maxHeightAfterRemoval);
    }
}


public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}