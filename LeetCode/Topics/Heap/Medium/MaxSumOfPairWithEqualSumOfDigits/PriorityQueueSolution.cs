using System.Collections.Generic;
using System.Linq;

namespace Studying.LeetCode.Topics.Heap.Medium.MaxSumOfPairWithEqualSumOfDigits
{
    public class PriorityQueueSolution : ISolution
    {
        public int MaximumSum(int[] nums)
        {
            var sums = new Dictionary<int, (int, int)>();

            foreach (var num in nums)
            {
                var sumOfDigits = GetDigitSum(num);

                if (!sums.TryAdd(sumOfDigits, (num, 0)))
                {
                    if (num > sums[sumOfDigits].Item1)
                    {
                        sums[sumOfDigits] = (num, sums[sumOfDigits].Item1);
                    }
                    else if (num > sums[sumOfDigits].Item2)
                    {
                        sums[sumOfDigits] = (sums[sumOfDigits].Item1, num);
                    }
                }
            }

            if (sums.Count == nums.Length)
            {
                return -1;
            }

            return sums.Where(x => x.Value.Item2 > 0).Max(el => el.Value.Item1 + el.Value.Item2);
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
}
