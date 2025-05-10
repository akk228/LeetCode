using System;

namespace LeetCode.Topics.Searching.Medium.FindFirstAndLastPositionOfElementInSortedArray;

/// <summary>
/// 34. Find First and Last Position of Element in Sorted Array
/// </summary>
public interface ISolution
{
    /// <summary>
    /// Finds the first and last position of a target element in a sorted array.
    /// </summary>
    /// <param name="nums">The sorted array of integers.</param>
    /// <param name="target">The target integer to find.</param>
    /// <returns>An array containing the first and last position of the target element, or [-1, -1] if not found.</returns>
    int[] SearchRange(int[] nums, int target);
}
