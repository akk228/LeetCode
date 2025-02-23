namespace LeetCode.Topics.BinaryTrees.Hard.RecoverTreeFromPreorderTraversal;

public class MySolution : ISolution
{
    public TreeNode RecoverFromPreorder(string traversal)
    {
        var startIndex = 0;

        while (startIndex < traversal.Length - 1 && traversal[startIndex + 1] != '-') startIndex++;

        var currentValue = Convert.ToInt32(traversal.Substring(0, startIndex + 1));
        var root = new TreeNode(currentValue);
        var nodeTraversalStack = new Stack<(TreeNode Node, int Depth)>();

        nodeTraversalStack.Push((root, 0));

        for (var tPos = startIndex + 1; tPos < traversal.Length; tPos++)
        {
            var currentDepth = 0;

            while (traversal[tPos] == '-') 
            {
                currentDepth++;
                tPos++;
            }

            startIndex = tPos;

            while (tPos < traversal.Length - 1 && traversal[tPos + 1] != '-') tPos++;

            currentValue = Convert.ToInt32(traversal.Substring(startIndex, tPos - startIndex + 1));
            
            var previousNodeDepthPair = nodeTraversalStack.Peek();

            if (currentDepth > previousNodeDepthPair.Depth)
            {
                previousNodeDepthPair.Node.left = new TreeNode(currentValue);
                nodeTraversalStack.Push((previousNodeDepthPair.Node.left, currentDepth));
                continue;
            }

            while (nodeTraversalStack.Count > 0 && currentDepth <= previousNodeDepthPair.Depth) previousNodeDepthPair = nodeTraversalStack.Pop();

            previousNodeDepthPair.Node.right = new TreeNode(currentValue);
            nodeTraversalStack.Push((previousNodeDepthPair.Node.right, currentDepth));
        }

        return root;
    }
}
