namespace Studying.LeetCode.Topics.Heap.Medium.MaxSumOfPairWithEqualSumOfDigits;

public class StoreMaxValueSolution : ISolution
{
    public int MaximumSum(int[] nums)
    {
        var digitSumDict = new int[82];

        var maxSum = -1;

        foreach (var num in nums)
        {
            var digitSum = GetDigitSum(num);

            if (digitSumDict[digitSum] == 0)
            {
                digitSumDict[digitSum] = num;
                continue;
            }

            maxSum = Math.Max(num + digitSumDict[digitSum], maxSum);
            digitSumDict[digitSum] = Math.Max(num, digitSumDict[digitSum]);
        }

        return maxSum;
    }

    private int GetDigitSum(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }
}
