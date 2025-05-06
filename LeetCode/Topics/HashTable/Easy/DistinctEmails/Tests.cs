using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace LeetCode.Topics.HashTable.Easy.DistinctEmails;

[ExcludeFromCodeCoverage]
public class Tests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { new string[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" }, 2 },
            new object[] { new string[] { "a@leetcode.com", "b@leetcode.com", "c@leetcode.com" }, 3 },
            new object[] { new string[] { "test.email+alex@leetcode.com", "test.email.leet+alex@code.com" }, 2 }
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestNumUniqueEmails(string[] emails, int expected)
    {
        var solution = new Solution();
        int result = solution.NumUniqueEmails(emails);
        Assert.Equal(expected, result);
    }
}
