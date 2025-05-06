namespace LeetCode.Topics.TwoPointers.Medium.MovePiecesToObtainTheString;

public class Solution1 : ISolution
{
    private const char R = 'R';
    private const char L = 'L';
    private const char underScore = '_';

    public bool CanChange(string start, string target)
    {
        var patternIndex = 0;
        var targetIndex = 0;
        var pattern = start.ToCharArray();
        var matchingTarget = target.ToCharArray();

        while (patternIndex < start.Length && targetIndex < target.Length)
        {
            if(matchingTarget[targetIndex] == underScore) {
                targetIndex++;
                continue;
            }

            if(matchingTarget[targetIndex] == L)
            {
                switch (pattern[patternIndex])
                {
                    case underScore:
                        patternIndex++;
                        continue;
                    case R:
                        return false;
                    case L when patternIndex >= targetIndex:
                        (pattern[patternIndex], pattern[targetIndex]) = (pattern[targetIndex], pattern[patternIndex]);
                        patternIndex = ++targetIndex;
                        break;
                    default:
                        return false;
                }
            }

            if(matchingTarget[targetIndex] == R)
            {
                switch (pattern[patternIndex])
                {
                    case underScore:
                        patternIndex++;
                        continue;
                    case L:
                        return false;
                    case R when patternIndex <= targetIndex:
                        (matchingTarget[patternIndex], matchingTarget[targetIndex]) = (matchingTarget[targetIndex], matchingTarget[patternIndex]);
                        targetIndex = ++patternIndex;
                        break;
                    default:
                        return false;
                }
            }
        }

        return pattern.SequenceEqual(matchingTarget);
    }
}