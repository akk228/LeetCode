namespace LeetCode.Topics.Heap.Medium.ZeroArrayTransformationIII;

/// <summary>
/// 3362. Zero Array Transformation III
/// </summary>

public class Solution
{
    private const int Left = 0;
    private const int Right = 1;

    public int MaxRemoval(int[] nums, int[][] queries)
    {
        var mainQuerisPQ = new PriorityQueue<int[], int[]>(
            queries.Select(q => (q, q)),
            Comparer<int[]>.Create(CompareQueries));
        var operationCount = 0;

        for (var pos = 0; pos < nums.Length; pos++)
        {
            if (mainQuerisPQ.Count == 0) return nums.Max() == 0 ? queries.Length - operationCount : -1;
            if (nums[pos] == 0) continue;
            
            var deletionCostQueue = new PriorityQueue<int[], int>();
           
            while (mainQuerisPQ.Count > 0)
            {
                var query = mainQuerisPQ.Peek();
                
                if (query[Left] > pos) break;
                mainQuerisPQ.Dequeue();
                if (query[Right] < pos) continue;
                deletionCostQueue.Enqueue(query, -DeletionCost(query, nums));
            }

            while (nums[pos] > 0 && deletionCostQueue.Count > 0)
            {
                PerformQuery(deletionCostQueue.Dequeue(), nums);
                operationCount++;
            }

            if (nums[pos] > 0) return -1;

            while (deletionCostQueue.Count > 0)
            {
                var query = deletionCostQueue.Dequeue();
                mainQuerisPQ.Enqueue(query, query);
            }
        }

        return queries.Length - operationCount;
    }
    
    private int CompareQueries(int[] query_a, int[] query_b)
    {
        var result = query_a[Left].CompareTo(query_b[Left]);
        return result != 0 ? result : query_a[Right].CompareTo(query_b[Right]);
    }

    private int DeletionCost(int[] query, int[] nums)
    {
        var cost = 0;

        for (var i = query[Left]; i <= query[Right]; i++)
        {
            if (nums[i] > 0)
            {
                cost++;
            }
        }

        return cost;
    }

    private void PerformQuery(int[] query, int[] nums)
    {
        for (var i = query[Left]; i <= query[Right]; i++)
        {
            nums[i] = Math.Max(0, nums[i] - 1);
        }
    }

    /*
    Dumb Solution
    1) Put queries in priority queue with the priority of how much every query can subtract at a given step
    2) take query that subtracts the most
    3) delete this query
    4) reaevaluate
    */

    /*
    Less Dumb Solution
    1) Sort queries by the left pointer in asc, and for the same left by the right in asc too
    2) Start subtracting
    */
}