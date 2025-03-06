namespace LeetCode.Topics.DynamicProgramming.Medium.CheckIfNumberIsASumOfPowersOfThree;

public class MySolution : ISolution
{
    public bool CheckPowersOfThree(int n)
    {
        return IsPowerOfThree(n, 0);
    }

    public bool IsPowerOfThree(int n, int power) {
        if (n == 0)
        {
            return true;
        }
        
        var currentNum = (int)Math.Pow(3, power);

        if (currentNum > n)
        {
            return false;
        }

        if(IsPowerOfThree(n - currentNum, power + 1)) 
        {
            return true;
        }

        return IsPowerOfThree(n, power + 1);
    }
}
