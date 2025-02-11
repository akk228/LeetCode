namespace LeetCode.Topics.Heap.Easy.LargestNumberAfterDigitSwapsByParity;

public class Solution
{
    public int LargestInteger(int num)
    {
        var odds = new PriorityQueue<byte, byte>();
        var evens = new PriorityQueue<byte, byte>();
        var indices = new List<bool>();

        while (num > 0)
        {
            var digit = (byte)(num % 10);

            if (digit % 2 == 0)
            {
                evens.Enqueue(digit, digit);
                indices.Add(true);
            }
            else
            {
                odds.Enqueue(digit, digit);
                indices.Add(false);
            }
            
            num /= 10;
        }

        var result = 0;
        var multiplier = 1;
        
        foreach(var isEven in indices)
        {
            if (isEven) result += multiplier*evens.Dequeue();
            else result += multiplier*odds.Dequeue();
            
            multiplier *= 10;
        }

        return result;
    }
}