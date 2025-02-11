namespace LeetCode.Algos.StringMatching.LongestPrefixSuffix;

public class KMP
{
    // Your implementation will go here
    public static int[] LPS(in string pattern)
    {
        var lps = new int[pattern.Length];
        lps[0] = 0;
        var len = 0;
        var i = 1;

        while (i < pattern.Length)
        {
            if (pattern[i] == pattern[len])
            {
                len++;
                lps[i] = len;
                i++;
            }
            else
            {
                if (len != 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
        }
        return lps;
    }
}