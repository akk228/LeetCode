namespace LeetCode.Topics.DynamicProgramming.Medium.CheckIfNumberIsASumOfPowersOfThree;

public class IterativeSolution : ISolution
{
    public bool CheckPowersOfThree(int n)
    {
        while (n > 0)
        {
            if (n % 3 == 2)
            {
                return false;
            }
            n /= 3;
        }
        return true;
    }
}
