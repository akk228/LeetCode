using System.Diagnostics.CodeAnalysis;

namespace LeetCode.Algos.StringMatching.LongestPrefixSuffix
{
    [ExcludeFromCodeCoverage]
    public class KMPTests
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { "AAACAAAA", new int[] { 0, 1, 2, 0, 1, 2, 3, 3 } };
            yield return new object[] { "ABCDE", new int[] { 0, 0, 0, 0, 0 } };
            yield return new object[] { "AABAACAABAA", new int[] { 0, 1, 0, 1, 2, 0, 1, 2, 3, 4, 5 } };
            yield return new object[] { "AAABAAA", new int[] { 0, 1, 2, 0, 1, 2, 3 } };
            yield return new object[] { "ABABAC", new int[] { 0, 0, 1, 2, 3, 0 } };
            yield return new object[] { "baabaabaabaa", new int[] { 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 } };
            yield return new object[] { "aaafbcaaafa", new int[] { 0, 1, 2, 0, 0, 0, 1, 2, 3, 4, 1 } };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void LPS_Tests(string pattern, int[] expected)
        {
            int[] result = KMP.LPS(pattern);
            Assert.Equal(expected, result);
        }
    }
}