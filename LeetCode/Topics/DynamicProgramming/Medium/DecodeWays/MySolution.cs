using System;

namespace LeetCode.Topics.DynamicProgramming.Medium.DecodeWays;

public class MySolution : ISolution
{
    private const char Null = '0';

    public int NumDecodings(string s)
    {
        if (s[0] == Null)
        {
            return 0;
        }

        var optionCounts = new int[s.Length + 1];
        optionCounts[0] = 1;
        optionCounts[1] = 1;

        for (var i = 1; i < s.Length; i++)
        {
            if(s[i] != Null)
            {
                optionCounts[i + 1] = optionCounts[i];
            }

            if (s[i - 1] != Null && Convert.ToInt32(s.Substring(i - 1, 2)) <= 26)
            {
                optionCounts[i + 1] += optionCounts[i - 1];
            }
        }

        return optionCounts[^1];
    }
}
