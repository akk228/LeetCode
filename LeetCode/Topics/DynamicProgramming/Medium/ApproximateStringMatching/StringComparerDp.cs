namespace LeetCode.Topics.DynamicProgramming.Medium.ApproximateStringMatching;

public class StringComparerDp : IStringComparer
{
    private const int _insert = 0;
    private const int _delete = 1;
    private const int _substitute = 2;
    
    private readonly Dictionary<int, Move> _operations = new()
    {
        {_insert,     new Move(){Cost = 1, Text = 0, Pattern = 1}},
        {_delete,     new Move(){Cost = 1, Text = 1, Pattern = 0}},
        {_substitute, new Move(){Cost = 1, Text = 1, Pattern = 1}},
    };
    
    private struct Cell
    {
        public int Cost;
        public int Parent;
    }
    
    private struct Move
    {
        public int Cost { get; init; }
        public int Text { get; init; }
        public int Pattern { get; init; }
    }
    
    public int CompareCost(string text, string pattern, int textEnd, int patternEnd)
    {
        var costTable = new Cell[text.Length + 1, pattern.Length + 1];
        
        for (var i = 0; i <= text.Length; i++) costTable[i, 0] = new(){ Cost = i, Parent = _insert };
        for (var i = 0; i <= pattern.Length; i++) costTable[0, i] = new(){ Cost = i, Parent = _delete };

        var costs = new Cell[3];
        
        for (var textPos = 1; textPos <= text.Length; textPos++)
        {
            for (var patternPos = 1; patternPos <= pattern.Length; patternPos++)
            {
                foreach (var operation in _operations)
                {
                    costs[operation.Key] = new()
                    {
                        Cost = costTable[textPos - operation.Value.Text, patternPos - operation.Value.Pattern].Cost +
                               (operation.Key == _substitute
                                   ? MatchCost(text[textPos - 1], pattern[patternPos - 1])
                                   : operation.Value.Cost),
                        Parent = operation.Key
                    };
                }

                var lowestCost = costs.Min(x => x.Cost);
                costTable[textPos, patternPos] = costs.First(x => x.Cost == lowestCost);
            }
        }

        // ConsoleDisplay(costTable, text.Length, pattern.Length);
        
        return costTable[text.Length, pattern.Length].Cost;
    }
    
    private int MatchCost(char a, char b)
    {
        return a == b ? 0 : _operations[_substitute].Cost;
    }

    private void ConsoleDisplay(Cell[,] costTable, int textEnd, int patternEnd)
    {
        for (var textPos = 1; textPos <= textEnd; textPos++)
        {
            for (var patternPos = 1; patternPos <= patternEnd; patternPos++)
                Console.Write(costTable[textPos, patternPos].Cost + "  ");
            Console.WriteLine();
        }
    }
}