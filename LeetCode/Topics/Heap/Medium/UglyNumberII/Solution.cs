namespace LeetCode.Topics.Heap.Medium.UglyNumberII;

public class Solution
{
    private readonly long[] _uglyMutlipliers = [2,3,5];

    public int NthUglyNumber(int n)
    {
        var ugliesHS = new HashSet<long>();
        var ugliesPQ = new PriorityQueue<long, long>();
        var uglies = new int[n];
        
        ugliesPQ.Enqueue(1,1);
        ugliesHS.Add(1);

        for (var i = 0; i < n; i++)
        {
            uglies[i] = (int)ugliesPQ.Dequeue();

            foreach(var m in _uglyMutlipliers)
            {
                var uglyCandidate = (long)uglies[i]*m;

                if (ugliesHS.Add(uglyCandidate))
                {
                    ugliesPQ.Enqueue(uglyCandidate, uglyCandidate);
                }
            }
        }

        return uglies[n - 1];
    }
}