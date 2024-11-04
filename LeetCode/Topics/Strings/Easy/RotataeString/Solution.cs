namespace LeetCode.Topics.Strings.Easy.RotataeString;

/// <summary>
/// 796. Rotate String
/// </summary>
public interface ISolution
{
    bool RotateString(string s, string goal);
}

/// <remarks>
/// Time : O(s.Length^2)
/// Space : O(1)
/// </remarks>
public class SquareSolution : ISolution 
{
    public bool RotateString(string s, string goal) {
        if(s.Length != goal.Length) return false;
        
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] != goal[0]) continue;
            
            int matchingLength = 1, position = 1;

            while (s[(i + position) % s.Length] == goal[position] && matchingLength < s.Length)
            {
                matchingLength++;
                position = (position + 1) % goal.Length;
            }

            if (matchingLength == s.Length) return true;
            if (matchingLength > (s.Length + 1) / 2) return false;
        }

        return false;
    }
}

/// <remarks>
/// Time : O(s.Length)
/// Space : O(s.Length)
/// </remarks>
public class LinearSolution : ISolution
{
    public bool RotateString(string s, string goal) {
        if(s.Length != goal.Length) return false;
        return (s + s).Contains(goal);
    }
}