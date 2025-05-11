#nullable disable

namespace LeetCode.Topics.Graphs.Medium.CloneGraph;

public class RecursiveDFS : ISolution
{
    public Node CloneGraph(Node node)
    {
        var visitedNodes = new Dictionary<int, Node>();

        return CloneNode(node, visitedNodes);
    }

    private Node CloneNode(Node node , Dictionary<int, Node> visited)
    {
        if (node is null)
        {
            return null;
        }

        var nodeCopy = new Node(node.val);
        visited.Add(nodeCopy.val, nodeCopy);

        foreach (var childNode in node.neighbors)
        {
            if (visited.ContainsKey(childNode.val))
            {
                nodeCopy.neighbors.Add(visited[childNode.val]);
            }
            else
            {
                var childCopy = CloneNode(childNode, visited);
                if (childCopy is not null)
                {
                    nodeCopy.neighbors.Add(childCopy);
                }
            }
        }

        return nodeCopy;
    }
}
