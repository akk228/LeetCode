namespace LeetCode.Topics.DynamicProgramming.Medium.ApproximateStringMatching;

public interface IStringComparer
{
    int CompareCost(string text, string pattern, int textEnd, int patternEnd);
}