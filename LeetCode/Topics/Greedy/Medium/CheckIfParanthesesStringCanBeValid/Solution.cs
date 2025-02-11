namespace LeetCode.Topics.Greedy.Medium.CheckIfParanthesesStringCanBeValid;

public class Solution
{
    public bool CanBeValid(string s, string locked)
    {
        if (s.Length % 2 != 0) return false;

        var opened = new Stack<int>();
        var swaps = new Stack<int>();

        for (var i = 0; i < s.Length; i++)
        {
            if (locked[i] == '0')
            {
                swaps.Push(i);
            }
            else if (s[i] == '(')
            {
                opened.Push(i);
            }
            else
            {
                if (opened.Count > 0)
                {
                    opened.Pop();
                }
                else if (swaps.Count > 0)
                {
                    swaps.Pop();
                }
                else
                {
                    return false;
                }
            }
        }

        while (
            opened.Count > 0 && 
            swaps.Count > 0 &&
            swaps.Peek() > opened.Peek())
        {
            swaps.Pop();
            opened.Pop();
        }

        return opened.Count == 0;
    }
}