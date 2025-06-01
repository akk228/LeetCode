using System;

namespace LeetCode.Topics.Strings.Medium.ZigzagConversion;

public class Solution : ISolution
{
    public string Convert(string s, int numRows) {
        if (numRows == 1) return s;
        var period = 2*(numRows - 1);
        var zigzag = new char[s.Length];
        var minAmplitude = Math.Min(numRows, s.Length);
        var pos = 0;

        for (var uniquePos = 0; uniquePos < minAmplitude; uniquePos++)
        {
            var start1 = uniquePos;
            var start2 = period - uniquePos;
            var move = 0;

            if (start1 == 0 || start1 == numRows - 1)
            {
                while (start1 < s.Length && pos < s.Length)
                {
                    zigzag[pos] = s[start1];
                    start1 += period;

                    if (++pos >= s.Length)
                    {
                        break;
                    }
                }
            }
            else
            {
                while ((start1 < s.Length || start2 < s.Length) && pos < s.Length)
                {
                    if (move % 2 == 0)
                    {
                        zigzag[pos] = s[start1];
                        start1 += period;
                    }
                    else
                    {
                        zigzag[pos] = s[start2];
                        start2 += period;
                    }

                    if (++pos >= s.Length)
                    {
                        break;
                    }

                    move++;
                }
            }

            if (pos >= s.Length)
            {
                break;
            }
        }

        return new string(zigzag);
    }
}
