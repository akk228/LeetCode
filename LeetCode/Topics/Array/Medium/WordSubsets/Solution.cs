namespace LeetCode.Topics.Array.Medium.WordSubsets;
using System;

public class Solution 
{
    public IList<string> WordSubsets(string[] words1, string[] words2)
    {
        var referenceFrequencies = new int[26];
        var currentReferences = new int[26];
        var result = new List<string>();

        foreach (var word in words2)
        {
            foreach (var letter in word)
            {
                currentReferences[(int)(letter - 'a')]++;
            }

            for (var i = 0; i < 26; i++)
            {
                referenceFrequencies[i] = Math.Max(referenceFrequencies[i], currentReferences[i]);
                currentReferences[i] = 0;
            }
        }

        foreach (var word in words1)
        {
            Array.Copy(referenceFrequencies, currentReferences, currentReferences.Length);
            
            if (IsSubset(word, currentReferences))
            {
                result.Add(word);
            }
        }

        return result;
    }

    private bool IsSubset(string word, int[] reference)
    {
        foreach (var ch in word)
        {
            reference[ch - 'a']--;
        }

        return !reference.Any(freq => freq > 0);
    }
}