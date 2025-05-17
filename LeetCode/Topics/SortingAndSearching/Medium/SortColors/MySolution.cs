using System;

namespace LeetCode.Topics.SortingAndSearching.Medium.SortColors;

public class MySolution : ISolution
{
    public void SortColors(int[] nums)
    {
        var start = 0;

        for (var color = 0; color <= 2; color++)
        {
            start = SortColor(color, start, nums);
        }
    }

    /// <summary>
    /// Puts elements of a certain color all together starting from a specified index
    /// </summary>
    /// <param name="color">color to sort</param>
    /// <param name="start">starting index of sorting</param>
    /// <return>
    /// Index of the next element after the last element with the color <paramref name="color"/>
    /// </returns>
    private int SortColor(int color, int start, int[] nums)
    {
        if (start >= nums.Length)
        {
            return start;
        }

        var lastColor = start;

        for (var pos = start; pos < nums.Length; pos++)
        {
            if (nums[pos] == color)
            {
                (nums[lastColor], nums[pos]) = (nums[pos], nums[lastColor]);
                lastColor++;
            }
        }

        return lastColor;
    }
}
