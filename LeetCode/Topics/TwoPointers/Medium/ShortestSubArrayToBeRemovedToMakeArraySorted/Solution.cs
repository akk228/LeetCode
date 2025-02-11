namespace LeetCode.Topics.TwoPointers.Medium.ShortestSubArrayToBeRemovedToMakeArraySorted;

public class Solution {
    public int FindLengthOfShortestSubarray(int[] arr)
    {
        if (arr.Length == 1)
        {
            return 0;
        }

        var left = 0;
        var right = arr.Length - 1;

        while (left + 1 < arr.Length && arr[left + 1] >= arr[left])
        {
            left++;
        }

        if (left == arr.Length - 1)
        {
            return 0;
        }

        while (right - 1 >= 0 && arr[right - 1] <= arr[right])
        {
            right--;
        }

        var minDelete = Math.Min(right, arr.Length - left - 1);
        var rightCutOff = right - 1;
        var leftCutOff = 0;

        
        while (leftCutOff <= left)
        {
            while (rightCutOff + 1 < arr.Length && arr[leftCutOff] > arr[rightCutOff + 1])
            {
                rightCutOff++;
            }

            if (rightCutOff == arr.Length) return minDelete;
            
            var result = rightCutOff - leftCutOff;

            if (result < minDelete)
            {
                minDelete = result;
            }

            leftCutOff++;
        }

        return minDelete;
    }
}