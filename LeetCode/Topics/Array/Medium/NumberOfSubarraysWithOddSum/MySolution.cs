namespace LeetCode.Topics.Array.Medium.NumberOfSubarraysWithOddSum;

public class MySolution : ISolution
{
    private const int Mod = 1000000007;

    public int NumOfSubarrays(int[] nums)
    {
        var odd = 0;
        var prefixSum = 0;

        foreach (var num in nums)
        {
            prefixSum += num;
            odd += prefixSum % 2;
        }

        var even = nums.Length - odd;

        return (int)((long)odd*(even + 1) % Mod);
    }
}
