// filepath: /C:/Users/andre/Documents/Studying/LeetCode/LeetCode/Topics/Stack/Medium/RemoveAllOccurencesOfaSubstring/Tests.cs
using System;
using System.Collections.Generic;
using Xunit;

namespace Stack.Medium.RemoveAllOccurencesOfSubString
{
    public class Tests
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { "daabcbaabcbc", "abc", "dab" };
            yield return new object[] { "axxxxyyyyb", "xy", "ab" };
            yield return new object[] { "aabbaabbaabb", "aabb", "" };
            yield return new object[] { "pqrstuv", "xyz", "pqrstuv" };
            yield return new object[] { "aaaaa", "aa", "a" };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void RemoveOccurrencesTests(string s, string part, string expected)
        {
            var solution = new Solution();
            string result = solution.RemoveOccurrences(s, part);
            Assert.Equal(expected, result);
        }
    }
}
