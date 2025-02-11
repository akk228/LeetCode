namespace LeetCode.Topics.TwoPointers.Medium.MovePiecesToObtainTheString;

public class Tests
{
    public static IEnumerable<object[]> TestData() => new List<object[]>()
    {
        new object[] { "_R", "R_", false },
        new object[] { "__LR__", "L___R_", true },
        new object[] { "_L__R__R_", "L______RR", true },
        new object[] { "R_L_", "__LR", false },
        new object[] { "R_R_", "R_R_", true },
        new object[] { "R__L", "RL__", true },
        new object[] { "_L__R__R_L", "L______RR_", false },
        new object[] { "_L", "LR", false },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void MovePiecesToObtainTheString(string input, string target, bool expected)
    {
        var actual = new Solution2().CanChange(input, target);
        
        Assert.Equal(expected, actual);
    }
}