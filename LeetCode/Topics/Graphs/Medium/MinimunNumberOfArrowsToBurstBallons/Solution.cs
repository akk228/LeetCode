namespace LeetCode.Topics.Graphs.Medium.MinimunNumberOfArrowsToBurstBallons;
using System;
public class Solution {
    public int FindMinArrowShots(int[][] points)
    {
        Array.Sort(points, (a, b) => a[0].CompareTo(b[0]));
        
        var lastPoint = points[0][1];
        var arrows = 1;

        foreach (var point in points)
        {
            if (point[0] > lastPoint)
            {
                arrows++;
                lastPoint = point[1];
            }
            lastPoint = Math.Min(lastPoint, point[1]);
        }
        return arrows;
    }
}