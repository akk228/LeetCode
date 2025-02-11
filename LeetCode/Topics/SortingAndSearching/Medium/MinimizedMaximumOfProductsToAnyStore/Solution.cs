namespace LeetCode.Topics.SortingAndSearching.Medium.MinimizedMaximumOfProductsToAnyStore;

public class Solution
{
    public int MinimizedMaximum(int n, int[] quantities)
    {
        var maxQuantity = quantities.Max();
        var minQuantity = 1;
        
        // we have to find minQuantity for which we can distribute
        // right will always contain value for which distribution is possible
        while (minQuantity < maxQuantity)
        {
            var mid = minQuantity + (maxQuantity - minQuantity) / 2;

            if (CanDistribute(quantities, mid, n))
            {
                maxQuantity = mid;
            }
            else
            {
                minQuantity = mid + 1;
            }
        }

        return maxQuantity;
    }
    
    private bool CanDistribute(int[] quantities, int upperBound, int storeCount)
    {
        var distributedProductsCount = 0;
        var remainingProductQuantity = quantities[distributedProductsCount];

        // fill one store at every loop iteration
        for (var stores = 1; stores <= storeCount; stores++)
        {
            if (remainingProductQuantity <= upperBound)
            {
                // we distributed current product in full
                distributedProductsCount++;
                // if all products have been distributed we check if there are any stores left
                if (distributedProductsCount >= quantities.Length)
                {
                    // we distributed all products, and some stores are left unoccupied
                    return true;
                }
                // if not  all products have been distributed we assign to the remaining quantity
                // the quantity of the new next product
                remainingProductQuantity = quantities[distributedProductsCount];
            }
            else
            {
                // if remaining quantity is greater than the quantity we can put in one container
                // we fill one container to the fullest
                remainingProductQuantity -= upperBound;
            }
        }
        // we reach this point only if there are some products left undistributed
        return false;
    }
}