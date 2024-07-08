
using WebProject.Models;

namespace WebProject.BL
{
    public interface IBucketItemService
    {
        public Task<int> AddPresentToCart(BucketItem present);
        public Task<int> DeletePresentFromCart(int opId);
        public Task<List<BucketItem>> GetPresentsOrder();
        public Task<List<BucketItem>> GetThePurchasesForEachPresent(int presentId);
        public Task<List<Present>> SortByTheMostPurchasedPresent();
        public Task<List<Present>> SortByTheMostExpensivePresent();
        public Task<List<BucketItem>> GetCartsByUserId(int userId);

    }
}
