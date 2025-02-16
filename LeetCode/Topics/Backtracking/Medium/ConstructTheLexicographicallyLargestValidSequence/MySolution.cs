namespace LeetCode.Topics.Backtracking.Medium.ConstructTheLexicographicallyLargestValidSequence;

public class MySolution : ISolution
{
    public int[] ConstructDistancedSequence(int n) {
        var sequence = new int[2*n - 1];
        var result = new int[2*n - 1];

        TryFillNext(n, sequence, result);

        return result;
    }

    private static void TryFillNext(int num, int[] sequence, int[] result)
    {
        if (num == 0)
        {
            if (SequenceCompareTo(sequence, result) > 0)
            {
                sequence.CopyTo(result, 0);
            }

            return;
        }

        var threshold = num > 1 ? num : 0;

        for (var i = 0; i + threshold < sequence.Length; i++)
        {
            if (num > 1 && sequence[i] == 0 && sequence[i + num] == 0)
            {
                sequence[i] = sequence[i + num] = num;
                TryFillNext(num - 1, sequence, result);
                sequence[i] = sequence[i + num] = 0;
            }
            else if (num == 1 && sequence[i] == 0)
            {
                sequence[i] = 1;
                TryFillNext(0, sequence, result);
                sequence[i] = 0;
            }
        }
    }

    private static int SequenceCompareTo(int[] arr1, int[] arr2)
    {
        for (var i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
        {
            if (arr1[i] > arr2[i]) return 1;
            if (arr1[i] < arr2[i]) return -1;
        }

        return 0;
    }
}
