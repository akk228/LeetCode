namespace LeetCode.Topics.DynamicProgramming.Easy.SieveOfEratosthenes;

public class WhenCalculatingPrimesUsingSieve
{
    [Fact]
    public void CalculateCorrectPrimes()
    {
        var sieve = new SieveOfEratosthenes(100);
        var primeSmallerThan20 = sieve.GetPrimeClosestToNumberFromBelow(20);
        Assert.Equal(19, primeSmallerThan20);

        var calculatedPrimes = sieve.GetCalculatedPrimes();
        Assert.True(
            calculatedPrimes.SequenceEqual(new []{0, 1, 2,3 ,5, 7, 11, 13, 17, 19, 23}));
    }
}