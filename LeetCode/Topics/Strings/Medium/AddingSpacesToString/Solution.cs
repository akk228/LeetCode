namespace LeetCode.Topics.Strings.Medium.AddingSpacesToString;

/// <summary>
/// 2109. Adding Spaces to a String
/// </summary>
/// <remarks>beats 90% tine, 65% space</remarks>
public class Solution
{
    public string AddSpaces(string s, int[] spaces)
    {
        var newString = new char[s.Length + spaces.Length];
        var charIndex = 0;
        var spaceIndex = 0;
        var mainIndex = charIndex + spaceIndex;


        while(charIndex < s.Length && spaceIndex < spaces.Length)
        {
            mainIndex = charIndex + spaceIndex;
            
            if (charIndex < spaces[spaceIndex])
            {
                newString[mainIndex] = s[charIndex];
                charIndex++;
            }else
            {
                newString[mainIndex] = ' ';
                spaceIndex++;
            }
        }

        while (charIndex < s.Length) {
            newString[charIndex + spaceIndex] = s[charIndex];
            charIndex++;
        }

        return new string(newString);
    }
}