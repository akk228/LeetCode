namespace LeetCode.Topics.Graphs.Medium.DigitOperationsToMakeTwoIntegersEqual;

public class Solution
{
    public int MinOperations(int n, int m)
    {
        var d = NumberOfDigits(n);
        var numbersHashSet = NonPrimes(d);
        var visited = numbersHashSet.ToDictionary(x => x, x => false);
        if (visited.ContainsKey(n)) visited[n] = true;
        else return -1;

        var queue = new Queue<(int,int)>();
        queue.Enqueue((n, n));

        var minCost = -1;
        
        while (queue.Count > 0)
        {
            var element = queue.Dequeue();
            var elementsToEnqueue = ElementsToEnqueue(d, element.Item1, element.Item2, visited);
            var result = CheckAnswer(elementsToEnqueue, m);

            if(minCost < result) minCost = result.Value;
            
            elementsToEnqueue.ForEach(element =>
            {
                queue.Enqueue(element);
                visited[element.Item1] = true;
            });
        }

        return minCost;
    }

    private int NumberOfDigits(int number)
    {
        var numberOfDigits = 0;

        while (number > 0)
        {
            number /= 10;
            numberOfDigits++;
        }

        return numberOfDigits;
    }

    private HashSet<int> NonPrimes(int v)
    {
        var max = 1;

        for (var i = 1; i <= v; i++) max *= 10;

        var nonPrimes = new bool[max];
        var pos = 2;

        while (pos < max)
        {
            if (!nonPrimes[pos])
            {
                var devidedByPrime = pos;
                while ((devidedByPrime += pos) < max) nonPrimes[devidedByPrime] = true;
            }

            pos++;
        }

        var result = new List<int>();
        
        for (var num = max / 10; num < nonPrimes.Length; num++)
            if(nonPrimes[num]) result.Add(num);
        
        return result.ToHashSet();
    }

    private List<(int, int)> ElementsToEnqueue(int d, int number, int currentSum, Dictionary<int,bool> visited)
    {
        var elements = new List<(int,int)>();
        var move = 1;
        var numberCopy = number;

        for (var i = 1; i <= d; i++)
        {
            var moveUp = number + move;
            if (numberCopy % 10 < 9 && visited.TryGetValue(moveUp, out var isVisited) && !isVisited)
                elements.Add((moveUp, currentSum + moveUp));
            
            var moveDown = number - move;

            if (!(i == d && numberCopy % 10 == 1) // this stands for the fact that if it is a main digit we can not derease it
                && numberCopy % 10 > 0 
                && visited.TryGetValue(moveDown, out var isVisited2) && !isVisited2)
                elements.Add((moveDown, currentSum + moveDown));

            move *= 10;
            numberCopy /= 10;
        }

        return elements;
    }

    private int? CheckAnswer(List<(int, int)> elements, int m)
    {
        var potentialResults = elements.Where(x => x.Item1 == m).ToList();
        if (potentialResults.Count == 0) return null;
        return potentialResults.Select( x => x.Item2).Min();
    }
}