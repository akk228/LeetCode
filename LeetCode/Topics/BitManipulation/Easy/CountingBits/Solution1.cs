namespace LeetCode.Topics.BitManipulation.Easy.CountingBits;

public class Solution1 : ISolution
{
    public int[] CountBits(int n)
    {
        var result = new int[n + 1];

        for(var i = 0; i <= n; i++)
        {
            var count = 0;
            var num = i;

            while(num > 0)
            {
                if((num & 1) == 1) count++;
                num >>= 1;
            }

            result[i] = count;
        }

        return result;
    }
}