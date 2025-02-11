using System;
using System.Collections.Generic;

namespace Stack.Medium.RemoveAllOccurencesOfSubString
{
    public class Solution
    {
        public string RemoveOccurrences(string s, string part) {
            var trimmed = new Stack<char>();

            foreach (var ch in s)
            {
                trimmed.Push(ch);

                if (trimmed.Count > 0 && IsProperSuffix(trimmed, ref part))
                {
                    for (var i = 0; i < part.Length; i++)
                    {
                        trimmed.Pop();
                    }
                }
            }

            return trimmed.Count > 0 ? new string(trimmed.Reverse().ToArray()) : string.Empty;
        }

        private bool IsProperSuffix(Stack<char> charStack, ref string suffix)
        {
            if (charStack.Count < suffix.Length)
            {
                return false;
            }

            var iterator = charStack.GetEnumerator();
            for (int i = suffix.Length - 1; i >= 0; i--)
            {
                iterator.MoveNext();
                if (iterator.Current != suffix[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}