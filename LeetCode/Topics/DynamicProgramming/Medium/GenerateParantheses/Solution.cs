using System.Runtime.InteropServices.JavaScript;

namespace LeetCode.Topics.DynamicProgramming.Medium.GenerateParantheses;

/// <summary>
/// 22. Generate Parentheses
/// </summary>
public class Solution {
    public IList<string> GenerateParenthesis(int n)
    {
        var combinations = new List<string>(){"()"};

        for(var i = 1; i < n; i++){
            combinations = Extend(combinations);
        }

        return combinations;
    }

    private List<string> Extend(List<string> combinations)
    {
        var newCombinations = new HashSet<string>();

        foreach(var combination in combinations)
        {
            var globalCount = 0;
            for (var right = combination.Length; right >= 0; right--)
            {
                var newCombination = combination.Insert(right, "()");
                if(globalCount == 0)
                    newCombinations.Add(newCombination);

                if (right > 0 && combination[right - 1] == ')') globalCount++;
                else globalCount--;
                
                var str = newCombination.ToArray();
                var left = right;
                var count = 0;

                while(left > 0)
                {
                    Swap(str, left, ref count);
                    if(count == 0) newCombinations.Add(new string(str));
                    left--;
                }
                
            }

        }

        return newCombinations.ToList();
    }

    private void Swap(char[] str, int index, ref int count){
        var temp = str[index - 1];

        str[index - 1] = str[index];
        str[index] = temp;

        if(temp == ')') count++;
        else count--;
    }
}