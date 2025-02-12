
using System.Text;

namespace Studying.LeetCode.Topics.Trie.Medium.LongestWordInDictionary;

public class Solution : ISolution
{
    private const char A = 'a';

    public string LongestWord(string[] words) {
        var trie = BuildTrie(words);

        return DFS(trie, string.Empty);
    }

    private string DFS(TrieNode node, string stringBuilder)
    {
        var result = stringBuilder.ToString();

        for (var i = 0; i < 26; i++)
        {
            if (node.Children[i] == null || !node.Children[i].IsLeaf) continue;

            var current = DFS(node.Children[i], stringBuilder + (char)(A + i)).ToString();

            if (current.Length > result.Length || 
                (current.Length == result.Length && string.Compare(current, result) < 0))
            {
                result = current;
            }
        }

        return result;
    }

    private static TrieNode BuildTrie(string[] words)
    {
        var root = new TrieNode(true);

        foreach (var word in words)
        {
            AddWord(root, in word);
        }

        return root;
    }

    private static void AddWord(TrieNode root, in string word)
    {
        foreach (var ch in word)
        {
            var pos = ch - A;
            
            if (root.Children[pos] is null)
            {
                root.Children[pos] = new TrieNode();
            }

            root = root.Children[pos];
        }

        root.IsLeaf = true;
    }

    private class TrieNode(bool isHead = false, bool isLeaf = false)
    {
        public TrieNode[] Children { get; } = new TrieNode[26];
        public bool IsHead { get; } = isHead;
        public bool IsLeaf { get; set;} = isLeaf;
    }
}