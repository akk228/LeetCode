namespace LeetCode.Topics.BinaryTrees.Medium.ConstructBinaryTreeFromPreorderAndPostorderTraversals;

public class MySolution : ISolution
{
        public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder) {
        var visited = new HashSet<int>();
        var root = new TreeNode(preorder[0]);
        GetChildren(root, 0, postorder.Length - 1, preorder, postorder, visited);
        return root;
    }

    private void GetChildren(TreeNode currentNode, int currentPreorderIndex, int currentPostorderIndex, int[] preorder, int[] postorder, HashSet<int> visited)
    {
        var nextPreorderIndex = currentPreorderIndex + 1;

        if (nextPreorderIndex >= preorder.Length || visited.Contains(preorder[nextPreorderIndex])) return;
        
        while (currentPostorderIndex >= 0 && postorder[currentPostorderIndex] != preorder[currentPreorderIndex]) currentPostorderIndex--;

        var nextPostorderIndex = currentPostorderIndex - 1;
        
        if (preorder[nextPreorderIndex] != postorder[nextPostorderIndex] && nextPostorderIndex >= 0)
        {
            currentNode.left = new(preorder[nextPreorderIndex]);
            currentNode.right = new(postorder[nextPostorderIndex]);

            visited.Add(postorder[nextPostorderIndex]);
            visited.Add(preorder[nextPreorderIndex]);

            GetChildren(currentNode.left, nextPreorderIndex, nextPostorderIndex, preorder, postorder, visited);

            while (nextPreorderIndex < preorder.Length && postorder[nextPostorderIndex] != preorder[nextPreorderIndex]) nextPreorderIndex++;

            GetChildren(currentNode.right, nextPreorderIndex, nextPostorderIndex, preorder, postorder, visited);
        }
        else
        {
            currentNode.left = new(preorder[nextPreorderIndex]);
            visited.Add(preorder[nextPreorderIndex]);
            GetChildren(currentNode.left, nextPreorderIndex, nextPostorderIndex, preorder, postorder, visited);
        }
    }
}
