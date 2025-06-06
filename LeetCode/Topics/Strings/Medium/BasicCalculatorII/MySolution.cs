namespace LeetCode.Topics.Strings.Medium.BasicCalculatorII;

public class MySolution : ISolution
{
    public int Calculate(string s) {
        var result = 0;
        var operation = '+';
        var expr = s.Replace(" ", string.Empty);
        var i = 0;

        while (i < expr.Length)
        {
            if (Char.IsDigit(expr[i]))
            {
                (int currentNum, int pos) = GetNumAndPos(i, ref expr);

                while (pos < expr.Length && expr[pos] != '+' && expr[pos] != '-' )
                {
                    int nextNum;
                    var op = expr[pos++];
                    (nextNum, pos) = GetNumAndPos(pos, ref expr);
                    
                    if (op == '*')
                    {
                        currentNum *= nextNum;
                    }
                    else
                    {
                        currentNum /= nextNum;
                    }
                }

                if (operation == '+')
                {
                    result += currentNum;
                }
                else
                {
                     result -= currentNum;
                }
                
                i = pos;
            }
            else
            {
                operation = expr[i];
                i++;
            }
        }

        return result;
    }

    private (int Num, int Pos) GetNumAndPos(int start, ref string s)
    {       
        var current = start + 1;
        
        while (current < s.Length && Char.IsDigit(s[current]))
        {
            current++;
        }

        return (Convert.ToInt32(s.Substring(start, current - start)), current);
    }
}
