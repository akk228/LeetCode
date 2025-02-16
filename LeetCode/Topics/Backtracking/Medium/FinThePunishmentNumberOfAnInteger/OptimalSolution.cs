namespace LeetCode.Topics.Backtracking.Medium.FinThePunishmentNumberOfAnInteger;

public class OptimalSolution : ISolution
{
    public int PunishmentNumber(int n)
    {
        var result = 0;

        for (var i = 1; i <= n; i++)
        {
            if (PartitioningResult(i*i, i))
            {
                result += i * i;
            }
        }

        return result;
    }

    private bool PartitioningResult(int num, int target)
    {
        if (target < 0 || target > num)
        {
            return false;
        }
        
        if (num == target)
        {
            return true;
        }

        for (var i = 10; i <= num; i *= 10)
        {
            var leftParittion = num / i;
            var rightPartition = num % i;

            if (PartitioningResult(leftParittion, target - rightPartition) || PartitioningResult(rightPartition, target - leftParittion))
            {
                return true;
            }
        }
        
        return false;
    }
}
