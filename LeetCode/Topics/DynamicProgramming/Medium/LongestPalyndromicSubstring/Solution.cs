namespace LeetCode.Topics.DynamicProgramming.Medium.LongestPalyndromicSubstring;

/// <summary>
/// 5. Longest Palindromic Substring
/// </summary>
/// <remarks>
/// Time : O(n^2)
/// Space : O(1)
/// </remarks>
public class Solution
{
    public string LongestPalindrome(string s)
    {
        var result = s[0].ToString();

        for (var mid = 0; mid < s.Length; mid++)
        {
            for (var start = 0; start <= mid; start++)
            {
                string palindrome;
                
                if (CheckPalindrome(s, start, mid, true, out palindrome) && palindrome.Length > result.Length)
                    result = palindrome;
                if (CheckPalindrome(s, start, mid, false, out palindrome) && palindrome.Length > result.Length)
                    result = palindrome;
            }
        }
        
        return result;
    }
    
    private bool CheckPalindrome(in string s, int start, int mid, bool isEven, out string palindrome)
    {
        palindrome = string.Empty;
        var end = 2*mid - start + (isEven ? 1 : 0);

        if (end >= s.Length) return false;

        var isPalindrome = true;
        var pos = 0;
        
        while (isPalindrome && start + pos <= mid)
        {
            isPalindrome = s[start + pos] == s[end - pos];
            pos++;
        }

        if (!isPalindrome) return false;
        
        palindrome = s.Substring(start, end - start + 1);
        return true;
    }
}