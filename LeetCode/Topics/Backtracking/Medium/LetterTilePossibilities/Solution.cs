namespace LeetCode.Topics.Backtracking.Medium.LetterTilePossibilities;

public class Solution : ISolution
{
    public int NumTilePossibilities(string tiles)
    {
        var uniqueSequences = new HashSet<string>();

        GenerateUniqueTranspositions(uniqueSequences, string.Empty, tiles);
        
        return uniqueSequences.Count;
    }

    private void GenerateUniqueTranspositions(HashSet<string> uniqueSequences, string current, string reminder)
    {
        if (reminder == string.Empty)
        {
            return;
        }

        for (var i = 0; i < reminder.Length; i++)
        {
            var result = current + reminder[i];

            if (uniqueSequences.Add(result))
            {
                GenerateUniqueTranspositions(uniqueSequences, result, reminder.Remove(i, 1));
            }
        }
    }
}
