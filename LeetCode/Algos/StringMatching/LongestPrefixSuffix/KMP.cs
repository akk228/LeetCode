namespace LeetCode.Algos.StringMatching.LongestPrefixSuffix;

public class KMP
{
    // Your implementation will go here
    public static int[] LPS(in string pattern)
    {
        var lps = new int[pattern.Length];
        var prefixLength = 0;
        var pos = 1;

        lps[0] = 0;
        // curr pos: proper prefix length is built so far
        // a1 a2 a3 a4        a5 a6 a7 a8 a9 a10
        //          (*pl + 1)       a1 a2 a3 *pos
        //                             a1 a2 a3 
        //___________________________________
        // a4 != a10
        //___________________________________
        // lps[*pl] > 0, say it will be 2, and if a3 == a10
        //___________________________________
        //  if a8 == a2 then we move pattern
        //  a1 a2 a3 a4 a5  |a1 a1 a2 a9 a10

        // prefixLength <= pos
        // lps[pos - 1] is correct for every iteration
        while (pos < pattern.Length)
        {
            if (pattern[pos] == pattern[prefixLength])
            {
                lps[pos++] = ++prefixLength;
            }
            else
            {
                if (prefixLength == 0)
                {
                    lps[pos++] = 0;
                }
                else
                {
                    prefixLength = lps[prefixLength - 1];
                }
            }
        }
        
        return lps;
    }
}