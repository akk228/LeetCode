namespace LeetCode.Topics.BitManipulation.Easy.PowerOfTwo;

/// <summary>
/// 231. Power of Two
/// 100 % time, 57.25 % memory
/// </summary>
public class Solution
{
    public bool IsPowerOfTwo(int n)
    {
        if(n == 0) return false;
        if(n == 1) return true;

        var mask = 1;
        var result = mask & n;

        while (result == 0 && result < n)
        {
            mask <<= 1;
            result = n & mask;
        }

        return result == n;
    }
}