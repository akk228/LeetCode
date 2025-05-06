#nullable disable

using System.Diagnostics;

namespace LeetCode.Topics.Strings.Easy.StringMatchingInAnArray;

/// <summary>
/// 1408. String Matching in an Array
/// O(N∗ M^2) time, O(N*M^2) space, where M = max_{word \in words}(word.Length)
/// </summary>
public class Solution
{
    public IList<string> StringMatching(string[] words)
    {
        var prefixTree = new PrefixTrie();

        foreach (var word in words)
        {
            prefixTree.Insert(word);
            
            for (int i = 1; i < word.Length; i++)
            {
                prefixTree.Insert(word[i..]);
            }
        }
        
        var result = new List<string>();

        foreach (var word in words)
        {
            if (prefixTree.SearchFrequency(word) > 1)
            {
                result.Add(word);
            }
        }

        return result;
    }
    
    private class TrieNode
    {
        public TrieNode()
        {
            Char = '\0';
            Children = new Dictionary<char, TrieNode>();
        }
        
        public TrieNode(char value)
        {
            Char = value;
            Children = new Dictionary<char, TrieNode>();
        }
        
        public char Char { get; init; }
        public int Frequency { get; set; }
        public Dictionary<char, TrieNode> Children { get; init; }
    }
    
    private class PrefixTrie
    {
        public TrieNode Root { get; } = new('\0');

        public void Insert(string word)
        {
            var current = Root;

            foreach (var ch in word)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                if (!current.Children.TryGetValue(ch, out TrieNode child))
                {
                    child = new TrieNode(ch);
                    current.Children.Add(ch, child);
                }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                current = child;
                current.Frequency++;
            }
        }

        public int SearchFrequency(string word)
        {
            var current = Root;

            foreach (var ch in word)
            {
                current.Children.TryGetValue(ch, out TrieNode child);
                current = child;
            }
            
            return current.Frequency;
        }
    }
}