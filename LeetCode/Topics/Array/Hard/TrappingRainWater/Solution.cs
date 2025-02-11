namespace LeetCode.Topics.Array.Hard.TrappingRainWater;

/// <summary>
/// 42. Trapping Rain Water
/// </summary>
public class Solution
{
    public int Trap(int[] height)
    {
        var totalVolume = 0;
        var highestPointIndex = 0;

        for (var i = 0; i < height.Length; i++) 
        {
            if (height[i] > height[highestPointIndex])
            {
                highestPointIndex = i;
            }
        }

        var currentVolume = 0;
        var topHeight = 0;

        for (var i = 0; i <= highestPointIndex; i++)
        {
            if (height[i] > topHeight)
            {
                totalVolume += currentVolume;
                currentVolume = 0;
                topHeight = height[i];
            }
            else
            {
                currentVolume += topHeight - height[i];
            }
        }

        currentVolume = topHeight = 0;

        for (var i = height.Length - 1; i >= highestPointIndex; i--)
        {
            if (height[i] >= topHeight)
            {
                totalVolume += currentVolume;
                currentVolume = 0;
                topHeight = height[i];
            }
            else
            {
                currentVolume += topHeight - height[i];
            }
        }

        return totalVolume;
    }
}