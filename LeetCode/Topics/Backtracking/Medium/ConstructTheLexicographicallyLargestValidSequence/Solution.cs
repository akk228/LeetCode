namespace LeetCode.Topics.Backtracking.Medium.ConstructTheLexicographicallyLargestValidSequence;

public class Solution : ISolution
{
    public int[] ConstructDistancedSequence(int n)
    {
        var result = new int[2 * n - 1];
        var used = new bool[n + 1];
        Backtrack(result, used, 0, n);
        return result;
    }

    private bool Backtrack(int[] result, bool[] used, int index, int n)
    {
        if (index == result.Length)
        {
            return true;
        }

        if (result[index] != 0)
        {
            return Backtrack(result, used, index + 1, n);
        }

        for (int num = n; num >= 1; num--)
        {
            if (used[num])
            {
                continue;
            }

            if (num == 1)
            {
                result[index] = num;
                used[num] = true;
                if (Backtrack(result, used, index + 1, n))
                {
                    return true;
                }
                result[index] = 0;
                used[num] = false;
            }
            else if (index + num < result.Length && result[index + num] == 0)
            {
                result[index] = num;
                result[index + num] = num;
                used[num] = true;
                if (Backtrack(result, used, index + 1, n))
                {
                    return true;
                }
                result[index] = 0;
                result[index + num] = 0;
                used[num] = false;
            }
        }

        return false;
    }
}
