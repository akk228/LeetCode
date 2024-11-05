namespace LeetCode.Topics.DynamicProgramming.Medium.ApproximateStringMatching;

public static class StringComparer
{
    private const int _insert = 0;
    private const int _delete = 1;
    private const int _substitute = 2;
    private static readonly int[] _operationCosts = [1, 1, 1];
    private static readonly int[][] _operations = { new int[] {1,0}, new int[] {0,1}, new int[] {1,1} };
    
    /// <summary>
    /// Method that to figure out how expensive is to find approximately matching patternin a string
    /// </summary>
    /// <param name="text">Text for matching</param>
    /// <param name="pattern">Pattern to find</param>
    /// <param name="textEnd">Index in text to finish comparison at</param>
    /// <param name="patternEnd">index in the pattern to finish comparison at</param>
    /// <returns>
    /// The cost of transforming part of the test that has length textLength to a pattern with length patternLength
    /// </returns>
    public static int CompareCost(string text, string pattern, int textEnd, int patternEnd)
    {
        if (textEnd == -1) return (patternEnd + 1) * _operationCosts[_insert];
        if (patternEnd == -1) return (textEnd + 1) * _operationCosts[_delete];

        var costs = new int[3];
        
        for(var i = _insert; i <= _substitute; i++)
        {
            costs[i] = CompareCost(
                                     text, 
                                     pattern, 
                                     textEnd - _operations[i][0], 
                                     patternEnd - _operations[i][1])
                                 + _operationCosts[i]*(i == _substitute ? MatchCost(text[textEnd], pattern[patternEnd]) : 1);
        }

        return costs.Min();
    }

    
    private static int MatchCost(char a, char b)
    {
        return a == b ? 0 : _operationCosts[_substitute];
    }
}