using System;

namespace LeetCode.Topics.DynamicProgramming.Medium.LongestUnequalAdjacentGroupsSubsequenceII;

public class MySolution : ISolution
{
    public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups) {
        if (words.Length == 1)
        {
            return new List<string> { words[0] };
        }

        var longestSubsequence = new int[words.Length];
        var nextElementInSubsequence = new int[words.Length];

        longestSubsequence[^1] = 0;
        nextElementInSubsequence[^1] = nextElementInSubsequence.Length - 1;

        for (var pos = words.Length - 1; pos >= 0; pos--)
        {
            var maxSubsequenceLength = 0;
            var posNextMaxSubsequence = pos;

            for (var next = pos + 1; next < words.Length; next++)
            {
                if (IsHammingDistanceOne(words[pos], words[next]) &&
                    groups[pos] != groups[next] &&
                    longestSubsequence[next] > maxSubsequenceLength)
                {
                    maxSubsequenceLength = longestSubsequence[next];
                    posNextMaxSubsequence = next;
                }
            }

            longestSubsequence[pos] = maxSubsequenceLength + 1;
            nextElementInSubsequence[pos] = posNextMaxSubsequence;
        }

        var start = 0;

        for (var pos = 1; pos < longestSubsequence.Length; pos++)
        {
            if (longestSubsequence[pos] > longestSubsequence[start])
            {
                start = pos;
            }
        }

        var subsequence = new List<string>
        {
            words[start]
        };
        
        if (longestSubsequence[start] == 1)
        {
            return subsequence;
        }

        int i = start;

        do
        {
            i = nextElementInSubsequence[i];
            subsequence.Add(words[i]);
        } while (nextElementInSubsequence[i] != i);

        return subsequence;
    }

    private bool IsHammingDistanceOne(string str1, string str2)
    {
        var hammingDistance = 0;
        var pos = 0;
        var minPos = Math.Min(str1.Length, str2.Length);
        
        while (pos < minPos)
        {
            if (str1[pos] != str2[pos])
            {
                hammingDistance++;
            }

            if (hammingDistance > 1)
            {
                return false;
            }

            pos++;
        }

        hammingDistance += pos >= str1.Length ? 
            str2.Length - pos :
            str1.Length - pos;
        
        return hammingDistance == 1 && str1.Length == str2.Length;
    }
}
