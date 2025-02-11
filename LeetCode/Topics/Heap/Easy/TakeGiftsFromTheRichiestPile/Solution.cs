namespace LeetCode.Topics.Heap.Easy.TakeGiftsFromTheRichiestPile;

public class Solution
{
    public long PickGifts(int[] gifts, int k) {
        var giftPriorityQueue = new PriorityQueue<int, int>(gifts.Select(x => (x, -x)));
    
        for (var time = 1; time <= k; time++)
        {
            var newGiftCount = (int)Math.Floor(Math.Sqrt(giftPriorityQueue.Dequeue()));
            giftPriorityQueue.Enqueue(newGiftCount, - newGiftCount);
        }

        return giftPriorityQueue.UnorderedItems.Sum(x => (long)x.Item1);
    }
}