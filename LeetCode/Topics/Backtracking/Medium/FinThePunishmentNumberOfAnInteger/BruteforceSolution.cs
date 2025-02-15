namespace LeetCode.Topics.Backtracking.Medium.FinThePunishmentNumberOfAnInteger;

public class BruteforceSolution : ISolution
{
    public int PunishmentNumber(int n)
    {
        var result = 0;

        for (var i = 1; i <= n; i++)
        {
            if (IsPartitionable(i))
            {
                result += i*i;
            }
        }

        return result;
    }

    private bool IsPartitionable(int num)
    {
        var stringOfDigits = (num*num).ToString();
        var partitions = PartitioningResult(stringOfDigits, 0, stringOfDigits.Length - 1);

        return partitions.Any(x => x == num);
    }

    private List<int> PartitioningResult(string digits, int start, int end)
    {
        var res = new List<int>();
        res.Add(Convert.ToInt32(digits.Substring(start, end - start + 1)));

        for (var pos = start; pos < end; pos++)
        {
            var result1 = PartitioningResult(digits, start, pos);
            var result2 = PartitioningResult(digits, pos + 1, end);

            result1.ForEach(x => {
                result2.ForEach(y => res.Add(x + y));
            });
        }

        return res;
    }
}