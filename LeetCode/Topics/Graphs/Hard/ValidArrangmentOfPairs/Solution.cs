namespace LeetCode.Topics.Graphs.Hard.ValidArrangmentOfPairs;
public class Solution
{ 
    private const int End = 1;
    private const int Start = 0;

    public int[][] ValidArrangement(int[][] pairs)
    {
        // key = start, values = list of indexes of segments that start from the key
        var starts = new Dictionary<int,List<int>>();

        for(var i = 0; i < pairs.Length; i++)
        {
            if(!starts.TryAdd(pairs[i][Start], [i])) starts[pairs[i][Start]].Add(i);
        }

        var traversal = new int[pairs.Length];
        var visitedSegments = new bool[pairs.Length];

        for (var i = 0; i < pairs.Length; i++)
        {
            var length = Dfs(pairs, starts, visitedSegments, traversal, i, 0);

            if(length == pairs.Length) break;
        }

        var result = new int[pairs.Length][];

        for(var k = 0; k < pairs.Length; k++) result[k] = pairs[traversal[k]];

        return result;
    }

    private int Dfs (
        int[][] pairs,
        Dictionary<int,List<int>> starts,
        bool[] visitedSegments,
        int[] traversal,
        int pos,
        int length
    )
    {
        // if we have visited this segment, than return
        if(visitedSegments[pos]) return length;

        // visit current segment
        visitedSegments[pos] = true;

        // else we record out current step to traversal
        traversal[length] = pos;
        length++;

        // if length reached the number of pairs, we succesfully traversed everything, and we can return
        if(length == visitedSegments.Length) return length;

        //we take the end of the current pair
        var end = pairs[pos][End];

        // now, we check all segments that start from end of the current pair
        if(starts.TryGetValue(end, out var listOfSegments))
        {
            foreach(var index in listOfSegments)
            {
                // we go to the net segment
                var newLength = Dfs(pairs, starts, visitedSegments, traversal, index, length);

                // if we traversed all segments, then we return
                if(newLength == visitedSegments.Length) return newLength;
            }
        }

        // if we haven't reached the end, then unvisit
        visitedSegments[pos] = false;
        
        return length;    
    }
}