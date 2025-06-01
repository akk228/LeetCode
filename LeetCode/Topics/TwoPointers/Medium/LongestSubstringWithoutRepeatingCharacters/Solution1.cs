using System;

namespace LeetCode.Topics.TwoPointers.Medium.LongestSubstringWithoutRepeatingCharacters;

public class Solution1 : ISolution
{
    public int LengthOfLongestSubstring(string s)
    {
        var currentChars = new HashSet<char>();
        var maxUniqueCharCount = 0;
        var start = 0;
        var end = 0;

        while (end < s.Length)
        {
            var nextChar = s[end];

            if (!currentChars.Contains(nextChar))
            {
                currentChars.Add(nextChar);
                end++;
                maxUniqueCharCount = Math.Max(maxUniqueCharCount, end - start);
                continue;
            }

            while (s[start] != nextChar)
            {
                currentChars.Remove(s[start]);
                start++;
            }

            if (start < end)
            {
                currentChars.Remove(s[start]);
                start++;
            }
        }

        return maxUniqueCharCount;
    }
}
