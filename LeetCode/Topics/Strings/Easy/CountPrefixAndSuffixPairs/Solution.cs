namespace LeetCode.Topics.Strings.Easy.CountPrefixAndSuffixPairs;

/// <summary>
/// 3042. Count Prefix and Suffix Pairs I
/// https://leetcode.com/problems/count-prefix-and-suffix-pairs-i/editorial
/// </summary>
public class Solution {
    public int CountPrefixSuffixPairs(string[] words) {
        var count = 0;

        for (var i = 0; i < words.Length; i++)
        {
            for (var j = i + 1; j < words.Length; j++)
            {
                if (words[j].EndsWith(words[i]) && words[j].StartsWith(words[i]))
                {
                    count++;
                }
            }
        }
        
        return count;
    }
}