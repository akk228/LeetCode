namespace LeetCode.Topics.BinaryTrees.Hard.RecoverTreeFromPreorderTraversal;

public class Solution : ISolution
{
    public TreeNode RecoverFromPreorder(string traversal)
    {
        var stack = new Stack<TreeNode>();
        for (int i = 0; i < traversal.Length;)
        {
            int level = 0;
            while (i < traversal.Length && traversal[i] == '-')
            {
                level++;
                i++;
            }

            int value = 0;
            while (i < traversal.Length && char.IsDigit(traversal[i]))
            {
                value = value * 10 + (traversal[i] - '0');
                i++;
            }

            var node = new TreeNode(value);
            if (stack.Count == level)
            {
                if (stack.Count > 0)
                {
                    stack.Peek().left = node;
                }
            }
            else
            {
                while (stack.Count > level)
                {
                    stack.Pop();
                }
                stack.Peek().right = node;
            }
            stack.Push(node);
        }

        while (stack.Count > 1)
        {
            stack.Pop();
        }

        return stack.Pop();
    }
}
