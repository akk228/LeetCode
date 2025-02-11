namespace LeetCode.Topics.BinaryTrees.Medium.ReverseOddLevelsOfBinaryTree;

public class Tests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>
    {
        new []{(int[])[0,1,2,0,0,0,0,1,1,1,1,2,2,2,2], [0,2,1,0,0,0,0,2,2,2,2,1,1,1,1]}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void ReverseCorrectrly(int[] nums, int[] expected)
    {
        var tree = TreeHelper.BuildTreeFromArray(nums.Select(x => (int?)x).ToArray());
        var root = new Solution().ReverseOddLevels(tree);
        var actualResult = TreeHelper.BuildArrayFromTree(root);
        
        Assert.Equal(actualResult.Select(x => x ?? 0).ToArray(), expected);
        
    }
}