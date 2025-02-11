namespace LeetCode.Topics.BitManipulation.Easy.CountingBits;

public class Solution2 : ISolution
{
    public int[] CountBits(int n)
    {
        var result = new int[n + 1];
        
        for(var i = 1; i <= n; i++)
            result[i] = result[i >> 1] + (i & 1);

        return result;
    }
}