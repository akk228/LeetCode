using System;

namespace LeetCode.Topics.Graphs.Medium.LexicographicallySmallestEquivalentString;

public class MySolution : ISolution
{
    public string SmallestEquivalentString(string s1, string s2, string baseStr)
    {
        var equivalenceGraph = new List<char>[26];

        for (int i = 0; i < 26; i++)
        {
            equivalenceGraph[i] = new List<char>();
        }
        for (int i = 0; i < s1.Length; i++)
        {
            equivalenceGraph[s1[i] - 'a'].Add(s2[i]);
            equivalenceGraph[s2[i] - 'a'].Add(s1[i]);
        }

        var newAlphabet = GetNewAlpahabet(equivalenceGraph);
        var result = new char[baseStr.Length];

        for (int i = 0; i < baseStr.Length; i++)
        {
            result[i] = newAlphabet[baseStr[i] - 'a'];
        }

        return new string(result);
    }

    private char[] GetNewAlpahabet(List<char>[] equivalenceGraph)
    {
        var newAlphabet = new char[26];
        var visited = new bool[26];

        for (int i = 0; i < 26; i++)
        {
            newAlphabet[i] = (char)('a' + i); // Initialize with the default character
        }

        for (var node = 0; node < 26; node++)
        {
            if (visited[node]) continue;

            var minChar = (char)('a' + node);
            var queue = new Queue<int>();
            var visitedCurrent = new List<int>();

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                visited[current] = true;
                visitedCurrent.Add(current);

                foreach (var neighbor in equivalenceGraph[current])
                {
                    var neighborIndex = neighbor - 'a';
                    if (!visited[neighborIndex])
                    {
                        queue.Enqueue(neighborIndex);
                        minChar = (char)Math.Min(minChar, neighbor);
                    }
                }
            }

            foreach (var visitedNode in visitedCurrent)
            {
                newAlphabet[visitedNode] = minChar;
            }
        }

        return newAlphabet;
    }
}
