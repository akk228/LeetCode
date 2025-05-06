using System.Collections;
using LeetCode.Topics.Heap.DataStructures.MaxHeap;

namespace LeetCode.Topics.Heap.DataStructers.MaxHeap.Tests;

public class MinHeapTests
{
    public static IEnumerable<object[]> BuildHeapTests => new List<object[]>()
    {
        new object[] {(int[])[9,8,8,3,4,1,2], 1, (int[])[1,2,3,4,8,8,9]},
        new object[] {(int[])[10,1,1], 1, (int[])[1,1,10]},
        new object[] {(int[])[1], 1, (int[])[1]},
        new object[] {(int[])[2, 1], 1, (int[])[1,2]},
    };

    [Theory]
    [MemberData(nameof(BuildHeapTests))]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
    public void BuildCorrectHeap(int[] items, int expectedMin, int[] expectedExtractedElements)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
    {
        var minHeap = new MinHeap<int>(items);
        var actualMin = minHeap.GetMin();
        
        Assert.Equal(expectedMin, actualMin);
    }
    
    [Theory]
    [MemberData(nameof(BuildHeapTests))]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
    public void ExtractElementsFromHeapInAscendingOrder(int[] items, int expectedMin, int[] expectedExtractedElements)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
    {
        var minHeap = new MinHeap<int>(items);
        var extractedElements = new List<int>();

        while (minHeap.Count > 0) extractedElements.Add(minHeap.ExtractMin());
        
        Assert.True(extractedElements.SequenceEqual(expectedExtractedElements));
    }
}