namespace LeetCode.Topics.Heap.Easy.FinalArrayStateAfterKMultiplicationOperationsI;

public class HeapTests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>()
    {
        new object[] { new int[]{ 1, 2, 3, 4 }, 1},
        new object[] { new int[]{ 3, 2, 1, 4 }, 1},
        new object[] { new int[]{ 3, 4, 1, 2 }, 1},
        new object[] { new int[]{ 3, 2, 1, 1 }, 1},
        new object[] { new int[]{ 3, 2, 1, 4, 5 ,0, 8 }, 0},
    };
    
    public static IEnumerable<object[]> TestDataSort() => new List<object[]>()
    {
        new object[] { new int[]{ 1, 2, 3, 4 }},
        new object[] { new int[]{ 3, 2, 1, 4 }},
        new object[] { new int[]{ 3, 4, 1, 2 }},
        new object[] { new int[]{ 3, 2, 1, 1 }},
        new object[] { new int[]{ 3, 2, 1, 4, 5 ,0, 8 }},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void BuildsHeapsAndExtractsCorrectRoot(int[] input, int min)
    {
        var minHeap = new Solution.Heap(input);
        var root = minHeap.Extract();
        Assert.Equal(min, root.Value);
    }
    
    [Theory]
    [MemberData(nameof(TestDataSort))]
    public void SortsCorrectlyViaHeap(int[] input)
    {
        var minHeap = new Solution.Heap(input);
        var previousElement = minHeap.Extract().Value;
        int currentElement;
        
        for (var i = 1; i < input.Length; i++)
        {
            currentElement = minHeap.Extract().Value;
            if(previousElement > currentElement) Assert.Fail();
        }
    }
}

public class SolutionTests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>()
    {
        new object[] { (int[])[2,1,3,5,6], 5, 2, (int[])[8,4,6,5,6]},
    };
    //  [2,1,3,5,6]

    [Theory]
    [MemberData(nameof(TestData))]
    public void SolveCorrectly(int[] nums, int ops, int multiplier, int[] expected)
    {
        var solution = new Solution().GetFinalState(nums, ops, multiplier);
        Assert.Equal(expected, solution);
    }
}