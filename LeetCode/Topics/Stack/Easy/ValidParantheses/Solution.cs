namespace LeetCode.Topics.Stack.Easy.ValidParantheses;
using System;

public class Solution
{
    private static readonly char[] Openings = ['(', '{', '['];
    private static readonly char[] Closings = [')', '}', ']'];

    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        
        foreach (var ch in s)
        {
            if (Openings.Any(o => o == ch))
            {
                stack.Push(ch);
            }
            else if (stack.Count > 0 && Array.IndexOf(Closings, ch) == Array.IndexOf(Openings, stack.Peek()))
            {
                stack.Pop();
            }
            else
            {
                return false;
            }
        }

        return stack.Count == 0;
    }
}