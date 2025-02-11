namespace LeetCode.Topics.BinaryTrees;

public static class TreeHelper
{
    public static int?[] BuildArrayFromTree(TreeNode root)
    {
        if (root is null) return [];
        
        // key = position, val = val
        var values = new Dictionary<int, int>();
        var queue = new Queue<(TreeNode,int)>();
        
        queue.Enqueue((root, 0));
        
        while (queue.Count > 0)
        {
            var (node, index) = queue.Dequeue();
            values.Add(index, node.Val);
            
            if (node.Left is not null) queue.Enqueue((node.Left, LeftChildIndex(index)));
            if (node.Right is not null) queue.Enqueue((node.Right, RightChildIndex(index)));
        }
        
        var maxIndex = values.Max(kvp => kvp.Key);
        var level = 0;
        
        while (maxIndex > 0)
        {
            level++;
            maxIndex = ParentIndex(maxIndex);
        }

        var length = 1;

        while (level > 0)
        {
            length += (int)Math.Pow(2, level);
            level--;
        }
        
        var array = new int?[length];

        foreach (var kvp in values)
        {
            array[kvp.Key] = kvp.Value;
        }
        
        return array;
    }
    
    public static TreeNode BuildTreeFromArray(int?[] nums)
    {
        if (nums[0] is null || nums.Length == 0) return null;
        var root = new TreeNode(nums[0].Value);
        AddNodeToTree(root, 0, nums);
        return root;
    }
    
    private static void AddNodeToTree(TreeNode root, int index, int?[] nums)
    {
        var leftChildIndex = LeftChildIndex(index);
        if (leftChildIndex < nums.Length && nums[leftChildIndex] is not null)
        {
            root.Left = new TreeNode(nums[leftChildIndex].Value);
            AddNodeToTree(root.Left, leftChildIndex, nums);
        }
        
        var rightChildIndex = RightChildIndex(index);
        if (rightChildIndex < nums.Length && nums[rightChildIndex] is not null)
        {
            root.Right = new TreeNode(nums[rightChildIndex].Value);
            AddNodeToTree(root.Right, rightChildIndex, nums);
        }
    }
    
    private static int LeftChildIndex(int i) => 2 * i + 1;
    private static int RightChildIndex(int i) => 2 * i + 2;
    private static int ParentIndex(int i) => (i - 1) / 2;
}

public class TreeBuilderTests
{
    public static IEnumerable<object[]> TreeBuilderTestData => new List<object[]>
    {
        new object[]{(int?[])[0,1,2]},
        new object[]{(int?[])[0,1,null]},
        new object[]{(int?[])[0,null,2]},
        new object[]{(int?[])[0,1,2,3,4,5,6]},
        new object[]{(int?[])[0,1,2,null,4,null,6]},
    };

    [Theory]
    [MemberData(nameof(TreeBuilderTestData))]
    public static void BuildsCorrectTreeFromArray(int?[] nums)
    {
        try
        {
            var tree = TreeHelper.BuildTreeFromArray(nums);
        }
        catch (Exception e)
        {
            Assert.Fail();
        }
    }

    [Theory]
    [MemberData(nameof(TreeBuilderTestData))]
    public static void BuildsCorrectArrayFromTree(int?[] expected)
    {
        var root = TreeHelper.BuildTreeFromArray(expected);
        var actualTreeArray = TreeHelper.BuildArrayFromTree(root);
        
        Assert.Equal(expected.Length, actualTreeArray.Length);
    }
}