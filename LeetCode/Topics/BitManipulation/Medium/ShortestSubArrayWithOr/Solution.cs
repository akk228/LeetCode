namespace LeetCode.Topics.BitManipulation.Medium.ShortestSubArrayWithOr;

public class Solution
{
    public int MinimumSubarrayLength(int[] nums, int k)
    {
        var left = 0;
        var right = 1;
        var counters = new int[32];
        var minLength = nums.Length + 1;

        Add(counters, nums[0]);

        while (right > left)
        {
            var current = GetNumber(counters);

            if(current < k)
            {
                if(right < nums.Length)
                {
                    Add(counters, nums[right]);
                    right++;
                }
                else
                {
                    break;
                }
            }
            else
            {
                var length = right - left;
                
                if (length < minLength)
                {
                    minLength = length;
                }
                
                Remove(counters, nums[left]);
                left++;
            }
        }

        return minLength <= nums.Length ? minLength : -1;
    }

    private void Add(int[] counters, int number)
    {
        var pos = 0;

        while (number > 0)
        {
            if((number & 1) == 1)
            {
                counters[pos]++;
            }
            number >>= 1;
            pos++;
        }
    }

    private void Remove(int[] counters, int number)
    {
        var pos = 0;

        while (number > 0)
        {
            if((number & 1) == 1)
            {
                counters[pos]--;
            }
            number >>= 1;
            pos++;
        }
    }

    private int GetNumber(int[] counters)
    {
        var result = 0;
        var mask = 1;

        for (var pos = 0; pos < counters.Length; pos++)
        {
            result |= counters[pos] > 0 ? mask : 0;
            mask <<= 1;
        }

        return result;
    }
}