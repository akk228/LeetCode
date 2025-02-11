namespace LeetCode.Topics.Array.Medium.MinimumNumberOfOperations;

public class Solution
{
    public int[] MinOperations(string boxes)
    {
        var rightSum = 0;
        var rightCount = 0;

        for (var i = 0; i < boxes.Length; i++)
        {
            if (boxes[i] == '1')
            {
                rightCount++;
                rightSum += i;
            }
        }

        var answers = new int[boxes.Length];
        var leftCount = 0;
        var leftSum = 0;

        for (var i = answers.Length - 1; i >= 0; i--)
        {
            var isOne = boxes[i] == '1';
            
            if (isOne)
            {
                rightCount--;
                rightSum -= i;
            }

            answers[i] = -i*(leftCount - rightCount) - rightSum + leftSum;

            if (isOne)
            {
                leftCount++;
                leftSum += i;
            }
        }

        return answers;
    }
}