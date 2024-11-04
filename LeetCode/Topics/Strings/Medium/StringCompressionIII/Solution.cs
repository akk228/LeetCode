using System.Text;

namespace LeetCode.Topics.Strings.Medium.StringCompressionIII;

public class Solution {
    public string CompressedString(string word) {
        var count = 0;
        var currentChar = word[0];
        var comp = new StringBuilder();
        
        foreach(var ch in word){
            if(ch == currentChar){
                count++;
            }else{
                CompressString(count, comp, currentChar);
                currentChar = ch;
                count = 1;
            }
        }
        
        CompressString(count, comp, currentChar);
        return comp.ToString();
    }

    private void CompressString(int count, StringBuilder comp, char currentChar)
    {
        var count9 = count / 9;
        for(var j = 0; j < count9; j++){
            comp.Append("9" + currentChar.ToString());
        }
        var reminder = count % 9;
        if(reminder == 0) return;
        comp.Append(reminder + currentChar.ToString());
    }
}