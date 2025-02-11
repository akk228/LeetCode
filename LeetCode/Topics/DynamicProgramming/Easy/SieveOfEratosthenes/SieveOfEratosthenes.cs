namespace LeetCode.Topics.DynamicProgramming.Easy.SieveOfEratosthenes;

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
            var pos = num;
            while (_sieve[pos]) pos--;
            return pos;
        }

        var previousPrime = CurrentLargestPrime;
        
        while (CurrentLargestPrime < num)
        {
            var pos = CurrentLargestPrime + 1;
            while (_sieve[pos]) pos++;

            for (var i = 2 * pos; i < _sieve.Length; i += pos) _sieve[i] = true;
            
            previousPrime = CurrentLargestPrime;
            CurrentLargestPrime = pos;
        }

        return previousPrime;
    }

    public IList<int> GetCalculatedPrimes()
    {
        var primes = new List<int>();
        for (var i = 0; i <= CurrentLargestPrime; i++) if(!_sieve[i]) primes.Add(i);
        return primes;
    }
}