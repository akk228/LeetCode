namespace LeetCode.Topics.Sorting.Medium.SortCharactersByFrequency;

/// <summary>
/// 451. Sort Characters By Frequency
/// </summary>
/// <remarks>
/// Time : O(n log(n) : Beats 61.9%
/// Space : O(n) : Beats 74.41%
/// </remarks>
public class Solution 
{
    public string FrequencySort(string s)
    {
        var frequencies = new Dictionary<char, int>();

        foreach(var ch in s)
            if(!frequencies.TryAdd(ch, 1))
                frequencies[ch]++;

        return string
            .Concat(frequencies
            .OrderByDescending(x => x.Value)
            .Select(x => new String(x.Key, x.Value)));
    }
}