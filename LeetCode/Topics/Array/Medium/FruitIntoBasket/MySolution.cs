using LeetCode.Topics.Array.Medium.FruitIntoBasket;

namespace LeetCode.Topics.Array.Medium.FruitIntoBasket;

public class MySolution : ISolution
{
    public int TotalFruit(int[] fruits)
    {
        var maxFruits = 1;
        var currentFruits = 1;
        var start = 0;
        var end = 1;
        var type1 = fruits[0];
        var type2 = fruits[0];
        
        while (end < fruits.Length)
        {
            if (fruits[end] == type1 || fruits[end] == type2)
            {
                currentFruits++;
            }
            else if (type1 == type2)
            {
                type2 = fruits[end];
                currentFruits++;
            }
            else
            {
                maxFruits = Math.Max(currentFruits, maxFruits);
                type2 = fruits[end];
                start = end - 1;
                type1 = fruits[start];
                currentFruits = 2;
                
                while (start > 0 && (fruits[start - 1] == type1 || fruits[start - 1] == type2)) 
                {
                    start--;
                    currentFruits++;
                }
            }
            end++;
        }
        
        maxFruits = Math.Max(currentFruits, maxFruits);
        
        return maxFruits;
    }
}
