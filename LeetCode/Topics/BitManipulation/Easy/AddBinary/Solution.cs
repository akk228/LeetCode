namespace LeetCode.Topics.BitManipulation.Easy.AddBinary;

/// <summary>
/// 67. Add Binary
/// Time : Beats 100 %, Memory : beats 79.15 %
/// </summary>
public class Solution
{
    public string AddBinary(string a, string b)
    {
        var resultInverse = new List<char>();
        var transferChar = '0';
        var pos = 0;

        while(pos < Math.Max(a.Length, b.Length))
        {
            var ch1 = pos < a.Length ? a[a.Length - 1 - pos] : '0';
            var ch2 = pos < b.Length ? b[b.Length - 1 - pos] : '0';

            if( ch1 == '0' && ch2 == '0')
            {
                resultInverse.Add(transferChar);
                transferChar = '0';
            }
            else if ( ch1 == '1' && ch2 == '1')
            {
                resultInverse.Add(transferChar);
                transferChar = '1';
            }else
            {
                if (transferChar == '1')
                {
                    resultInverse.Add('0');
                }
                else
                {
                    resultInverse.Add('1');
                }
            }
            pos++;
        }

        if (transferChar == '1')
        {
            resultInverse.Add('1');
        }
        resultInverse.Reverse();

        return new string(resultInverse.ToArray());
    }
}