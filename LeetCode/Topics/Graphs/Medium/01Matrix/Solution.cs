namespace LeetCode.Topics.Graphs.Medium._01Matrix;

/// <summary>
/// #542. 01 Matrix
/// </summary>
public interface ISolution
{
    int[][] UpdateMatrix(int[][] mat);
}
public class Solution1 : ISolution
{
    private record Element(int x, int y);
    private List<Element> _zeros = new List<Element>();

    public int[][] UpdateMatrix(int[][] mat) {
        for(int x = 0; x < mat.Length; ++x){
            for(int y = 0; y < mat[x].Length; ++y){
                if(mat[x][y] == 0)
                {
                    _zeros.Add(new Element(x, y));
                }
                else
                {
                    mat[x][y] = Int32.MaxValue;
                }
            }
        }

        foreach(var zero in _zeros){
            MatrixDfs(zero, mat);
        }

        return mat;
    }

    private void MatrixDfs(Element currentElement, int[][] mat, int distance = 0){
        var linkedNodes = new List<Element>();

        if(currentElement.x != 0)
        {
            linkedNodes.Add(new Element(currentElement.x - 1, currentElement.y));
        }
        if(currentElement.x != mat.Length - 1){
            linkedNodes.Add(new Element(currentElement.x + 1, currentElement.y));
        }
        if(currentElement.y != 0){
            linkedNodes.Add(new Element(currentElement.x, currentElement.y - 1));
        }
        if(currentElement.y != mat[currentElement.x].Length - 1){
            linkedNodes.Add(new Element(currentElement.x, currentElement.y + 1));
        }

        foreach(var element in linkedNodes){
            if(mat[element.x][element.y] > distance + 1){
                mat[element.x][element.y] = distance + 1;
                MatrixDfs(element, mat, distance + 1);
            }
        }
    }
}

public class Solution2 : ISolution
{
    private record Element(int x, int y);
    private  readonly int[][] _directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
    
    public int[][] UpdateMatrix(int[][] mat)
    {
        var queue = new Queue<Element>();
        var height = mat.Length;
        var width = mat[0].Length;
        
        for(int x = 0; x < mat.Length; ++x){
            for(int y = 0; y < mat[x].Length; ++y){
                if(mat[x][y] == 0)
                {
                    queue.Enqueue(new Element(x, y));
                }
                else
                {
                    mat[x][y] = -1;
                }
            }
        }

        while (queue.Count > 0)
        {
            var currentElement = queue.Dequeue();
            
            foreach (var shift in _directions)
            {
                var x = currentElement.x + shift[0];
                var y = currentElement.y + shift[1];

                if (x < 0 || x >= height || y < 0 || y >= width || mat[x][y] != -1) continue;
                queue.Enqueue(new Element(x, y));
                mat[x][y] = mat[currentElement.x][currentElement.y] + 1;
            }
        }
        
        return mat;
    }
}