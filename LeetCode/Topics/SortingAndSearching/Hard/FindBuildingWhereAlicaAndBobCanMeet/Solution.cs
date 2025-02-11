namespace LeetCode.Topics.Sorting.Hard.FindBuildingWhereAlicaAndBobCanMeet;
using System;
public class Solution
{
    public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
    {
        var buildingIds = new int[queries.Length];
        var orderedQueries = new Query[queries.Length];

        for (var i = 0; i < orderedQueries.Length; i++)
        {
            orderedQueries[i] = new Query()
            {
                AliceHeight = heights[queries[i][0]],
                BobHeight = heights[queries[i][1]],
                QueryIndex = i
            };
        }
        
        Array.Sort(orderedQueries);

        for (var i = 0; i < heights.Length; i++)
        {
            // var potentialQueries = Array.
        }

        throw new NotImplementedException();
    }

    private class Query : IComparable<Query>
    {
        public int AliceHeight { get; set; }
        public int BobHeight { get; set; }
        public int QueryIndex { get; set; }

        public int MeetIndex { get; set; } = -1;

        public int CompareTo(Query? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (other is null) return 1;
            var aliceHeightComparison = AliceHeight.CompareTo(other.AliceHeight);
            if (aliceHeightComparison != 0) return aliceHeightComparison;
            return BobHeight.CompareTo(other.BobHeight);
        }
    }
}