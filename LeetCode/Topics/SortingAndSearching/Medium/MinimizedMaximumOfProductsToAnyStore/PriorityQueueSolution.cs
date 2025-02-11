namespace LeetCode.Topics.SortingAndSearching.Medium.MinimizedMaximumOfProductsToAnyStore;
using System;
public class PriorityQueueSolution
{
    private struct ProductDistribution
    {
        public int Quantity { get; set; }
        public int StoreCount { get; set; }
    }
    public int MinimizedMaximum(int n, int[] quantities)
    {
        if (quantities.Length == n) return quantities.Max();
        
        var distribution = new PriorityQueue<ProductDistribution, int>(
            quantities.Select(x => (new ProductDistribution { Quantity = x, StoreCount = 1 }, x)),
            Comparer<int>.Create((x, y) => y.CompareTo(x)));

        for (var storeRemaining = 1; storeRemaining <= n - quantities.Length; storeRemaining++)
        {
            var product = distribution.Dequeue();
            product.StoreCount++;
            var priority = (product.Quantity + product.StoreCount - 1) / product.StoreCount;
            distribution.Enqueue(product, priority);
        }
        
        Array.BinarySearch(new int[]{}, distribution);
        
        var highestPriorityProduct = distribution.Peek();
        return (highestPriorityProduct.Quantity + highestPriorityProduct.StoreCount - 1) / highestPriorityProduct.StoreCount;
    }
}