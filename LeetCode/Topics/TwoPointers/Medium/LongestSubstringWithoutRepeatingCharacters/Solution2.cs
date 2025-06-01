using System;

namespace LeetCode.Topics.TwoPointers.Medium.LongestSubstringWithoutRepeatingCharacters;

public class Solution2 : ISolution
{
    public int LengthOfLongestSubstring(string s)
    {
        var charToNextIndex = new Dictionary<char, int>();
        var maxLen = 0;
        var left = 0;
        
        for (var right = 0; right < s.Length; right++)
        {
            if (charToNextIndex.ContainsKey(s[right]))
            {
                left = Math.Max(charToNextIndex[s[right]], left);
            }

            maxLen = Math.Max(maxLen, right - left + 1);
            charToNextIndex[s[right]] = right + 1;
        }

        return maxLen;
    }
}
