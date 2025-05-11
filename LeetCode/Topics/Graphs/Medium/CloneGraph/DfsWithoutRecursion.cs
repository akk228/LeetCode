#nullable disable
namespace LeetCode.Topics.Graphs.Medium.CloneGraph;

public class DfsWithoutRecursion : ISolution
{
        public Node CloneGraph(Node node)
    {
        if (node is null)
        {
            return null;
        }

        var visitedCopies = new Dictionary<int, Node>();
        var nodeStack = new Stack<Node>();
        var current = node;
        var head = new Node(current.val);

        visitedCopies.Add(current.val, head);
        nodeStack.Push(current);
        
        while (nodeStack.Count > 0)
        {
            current = nodeStack.Pop();
            
            foreach (var childNode in current.neighbors)
            {
                if (!visitedCopies.ContainsKey(childNode.val))
                {
                    visitedCopies.Add(childNode.val, new Node(childNode.val));
                    nodeStack.Push(childNode);
                }

                visitedCopies[current.val].neighbors.Add(visitedCopies[childNode.val]);
            }
        }

        return head;
    }
}
