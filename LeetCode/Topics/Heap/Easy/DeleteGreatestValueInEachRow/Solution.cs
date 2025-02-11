namespace LeetCode.Topics.Heap.Easy.DeleteGreatestValueInEachRow;

public class Solution
{
    public int DeleteGreatestValue(int[][] grid) 
    {
        foreach (var row in grid)
        {
            System.Array.Sort(row);
        }

        var sum = 0;

        for (var y = grid[0].Length - 1; y >= 0; y--)
        {
            var priorityQueue = new PriorityQueue<int, int>();

            foreach (var row in grid)
            {
                priorityQueue.Enqueue(row[y], - row[y]);
            }

            sum += priorityQueue.Peek();
        }

        return sum;
    }
}