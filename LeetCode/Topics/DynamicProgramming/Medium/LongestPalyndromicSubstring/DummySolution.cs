namespace LeetCode.Topics.DynamicProgramming.Medium.LongestPalyndromicSubstring;

public class DummySolution
{
    public string LongestPalindrome(string s) {
        var maxLength = 1;
        var maxPos = 0;
        for (var pos = 0; pos < s.Length; pos++)
        {
            var odd = LongestOddPalindrome(pos, ref s);
            var even = LongestEvenPalindrome(pos, ref s);

            if (maxLength < even)
            {
                maxLength = even;
                maxPos = pos; 
            }
            if (maxLength < odd)
            {
                maxLength = odd;
                maxPos = pos; 
            }
        }
        var startingIndex = maxPos - (maxLength - 1) / 2;
        return s.Substring(startingIndex, maxLength);
    }

    private int LongestOddPalindrome(int pos, ref string s)
    {
        var left = pos;
        var right = pos;

        while (left - 1 >= 0 && right + 1 < s.Length && s[left - 1] == s[right + 1]) 
        {
            left--;
            right++;
        }

        return right - left + 1;
    }

    private int LongestEvenPalindrome(int pos, ref string s)
    {
        var left = pos;
        var right = pos + 1;

        if ((right < s.Length && s[left] != s[right]) || right >= s.Length)
        {
            return 0;
        }

        while (left - 1 >= 0 && right + 1 < s.Length && s[left - 1] == s[right + 1]) 
        {
            left--;
            right++;
        }

        return right - left + 1;
    }

}