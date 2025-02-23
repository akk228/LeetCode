using System;

namespace LeetCode.Topics.BinaryTrees.Medium.ConstructBinaryTreeFromPreorderAndPostorderTraversals;

/// <summary>
/// 889. Construct Binary Tree from Preorder and Postorder Traversal
/// https://leetcode.com/problems/construct-binary-tree-from-preorder-and-postorder-traversal/
/// </summary>
public interface ISolution
{
    TreeNode ConstructFromPrePost(int[] preorder, int[] postorder);
}
