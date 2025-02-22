namespace LeetCode.Topics.HashTable.Medium.UniqueBinaryString;

public class Solution : ISolution
{
    public string FindDifferentBinaryString(string[] nums)
    {
        var set = new HashSet<string>(nums);
        var n = nums.Length;
        var binaryString = string.Empty;

        for (int i = 0; i < (1 << n); i++)
        {
            binaryString = Convert.ToString(i, 2).PadLeft(n, '0');
            if (!set.Contains(binaryString))
            {
                break;
            }
        }

        return binaryString;
    }
}
