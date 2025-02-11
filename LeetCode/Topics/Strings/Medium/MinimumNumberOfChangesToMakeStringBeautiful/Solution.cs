namespace LeetCode.Topics.Strings.Medium.MinimumNumberOfChangesToMakeStringBeautiful;

public class Solution {
    public int MinChanges(string s)
    {
        var substitutionCount = 0;

        for (var i = 0; i < s.Length; i += 2)
            if (s[i] != s[i + 1]) substitutionCount++;
        
        return substitutionCount;
    }
}