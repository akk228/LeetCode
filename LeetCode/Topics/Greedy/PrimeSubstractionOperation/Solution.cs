namespace LeetCode.Topics.Greedy.PrimeSubstractionOperation;

public class Solution
{
    private readonly SieveOfEratosthenes _sieve = new(1000);

    public bool PrimeSubOperation(int[] nums)
    {
        var diff = _sieve.GetPrimeClosestToNumberFromBelow(nums[0]);
        if (diff > 1) nums[0] -= diff;

        for (var i = 1; i < nums.Length; i++)
        {
            if(nums[i] <= nums[i - 1]) return false;
            diff = _sieve.GetPrimeClosestToNumberFromBelow(nums[i] - nums[i - 1]);
            if(diff <= 1) continue;
            var adjustedNum = nums[i] - diff;
            if(adjustedNum > nums[i - 1]) nums[i] = adjustedNum;
        }
        return true;
    }
}

public class SieveOfEratosthenes
{
    private readonly bool[] _sieve;
    
    public SieveOfEratosthenes(int capacity)
    {
        _sieve = new bool[capacity + 1];
        for (var i = 4; i < _sieve.Length; i *= 2) _sieve[i] = true;
        CurrentLargestPrime = 2;
    }

    public int CurrentLargestPrime { get; private set; }

    public int GetPrimeClosestToNumberFromBelow(int num)
    {
        if (num <= CurrentLargestPrime)
        {
            var pos = !_sieve[num] ? num - 1 : num;
            while (_sieve[pos]) pos--;
            return pos;
        }

        var previousPrime = CurrentLargestPrime;
        
        while (CurrentLargestPrime < num && CurrentLargestPrime < _sieve.Length)
        {
            var pos = CurrentLargestPrime + 1;

            while (pos < _sieve.Length && _sieve[pos]) pos++;

            if (pos >= _sieve.Length || _sieve[pos]) return CurrentLargestPrime;
            
            for (var i = 2 * pos; i < _sieve.Length; i += pos) _sieve[i] = true;
            
            previousPrime = CurrentLargestPrime;
            CurrentLargestPrime = pos;
        }

        if (CurrentLargestPrime >= _sieve.Length) CurrentLargestPrime = previousPrime;
        
        return previousPrime;
    }
}