using System;
using System.Collections.Generic;

namespace Stack.Medium.RemoveAllOccurencesOfSubString
{
    /// <summary>
    /// 1910. Remove All Occurrences of a Substring
    /// </summary>
    public class Solution : ISolution
    {
        public string RemoveOccurrences(string s, string part) {
            var trimmed = new Stack<char>();

            // Loop invaruiants:
            // 1. trimmed contains the characters of "s" that are not "part"
            // 2. part is the last part.Length characters of trimmed
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

            return trimmed.Count > 0 ? new string([.. trimmed.Reverse()]) : string.Empty;
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