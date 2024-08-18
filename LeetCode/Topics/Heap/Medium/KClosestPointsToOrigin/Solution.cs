namespace LeetCode.Topics.Heap.Medium.KClosestPointsToOrigin;

public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        var kClosestPoints = new int[k][];
        var pointsOrderedByDistance = new SortedDictionary<int, List<int[]>>();
        
        foreach (var point in points)
        {
            var distance = point[0] * point[0] + point[1] * point[1];

            if (pointsOrderedByDistance.ContainsKey(distance))
            {
                pointsOrderedByDistance[distance].Add(point);
            }
            else
            {
                var points_ = new List<int[]>();
                points_.Add(point);
                pointsOrderedByDistance.Add(distance, points_);
            }
        }

        var count = 0;
        foreach (var distanceDotsPair in pointsOrderedByDistance)
        {
            for (int i = count; i < k && i < count + distanceDotsPair.Value.Count; i++)
                kClosestPoints[i] = distanceDotsPair.Value[i - count];
            
            count += distanceDotsPair.Value.Count;
            
            if(count >= k) break;
        }

        return kClosestPoints;
    }
}