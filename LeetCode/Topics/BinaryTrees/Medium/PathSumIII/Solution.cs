namespace LeetCode.Topics.BinaryTrees.Medium.PathSumIII;


//  Definition for a binary tree node.
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
 
/// <summary>
/// #437. Path Sum III
/// </summary>
  public class Solution {
      public int PathSum(TreeNode root, int targetSum) {
          var count = 0;
          DfsTree(root, targetSum, ref count);
          return count;
      }

      private void DfsTree(TreeNode node, int targetSum, ref int count){
          if(node is null) return;
          DfsFromCurrentNode(node, targetSum, ref count);
          DfsTree(node.left, targetSum, ref count);
          DfsTree(node.right, targetSum, ref count);
      }
      private void DfsFromCurrentNode(TreeNode currentNode, int targetSum, ref int count, long currentSum = 0)
      {
          if(currentNode is null) return;

          currentSum += currentNode.val;

          if(currentSum == targetSum){
              count++;
          }

          DfsFromCurrentNode(currentNode.left, targetSum, ref count, currentSum);
          DfsFromCurrentNode(currentNode.right, targetSum, ref count, currentSum);
      }
  }