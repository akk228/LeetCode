namespace LeetCode.Topics.TwoPointers.Medium.MovePiecesToObtainTheString;

public class Solution2 : ISolution
{
    private const char R = 'R';
    private const char L = 'L';
    private const char _ = '_';

    public bool CanChange(string start, string target)
    {
        var patternIndex = 0;
        var targetIndex = 0;

        while (targetIndex < target.Length && patternIndex < start.Length)
        {
            if(target[targetIndex] == _) {
                targetIndex++;
                continue;
            }

            if(target[targetIndex] == L)
            {
                switch (start[patternIndex])
                {
                    case _:
                        patternIndex++;
                        continue;
                    case R:
                        return false;
                    case L when patternIndex >= targetIndex:
                        ++targetIndex;
                        ++patternIndex;
                        break;
                    default:
                        return false;
                }
                continue;
            }

            if(target[targetIndex] == R)
            {
                switch (start[patternIndex])
                {
                    case _:
                        patternIndex++;
                        continue;
                    case L:
                        return false;
                    case R when patternIndex <= targetIndex:
                        ++targetIndex;
                        ++patternIndex;
                        break;
                    default:
                        return false;
                }
            }
        }
        
        if (patternIndex < targetIndex)
        {
            for (var i = patternIndex; i < start.Length; i++)
                if (start[i] != _)
                    return false;
        }else if (patternIndex > targetIndex)
        {
            for (var i = targetIndex; i < target.Length; i++)
                if (target[i] != _)
                    return false;
        }
        
        return true;
    }
}