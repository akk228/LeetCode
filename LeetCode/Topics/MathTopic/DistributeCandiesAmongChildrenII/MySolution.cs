namespace LeetCode.Topics.MathTopic.DistributeCandiesAmongChildrenII;

public class MySolution
{
    public long DistributeCandies(int n, int limit) {
        long result = 0;

        for (var n1 = 0; n1 <= Math.Min(limit, n); n1++)
        {
            var remider = n - n1;
            var start = remider <= limit ? 0 : remider - limit;
            var end = Math.Min(limit, n - n1);
            result += start <= end ? (long)(end - start + 1) : 0;
        }

        return result;
    }
}
