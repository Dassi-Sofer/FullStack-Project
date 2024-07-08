using WebProject.Models;

namespace WebProject.DAL
{
    public interface IBItemDal
    {
        public Task<int> AddPresentToCartAsync(BucketItem present);
        //Task<int> AddToPresentCartAsync(Order o);
        public Task<int> DeletePresentFromCartAsync(int opId);
        public Task<List<BucketItem>> GetPresentsOrderAsync();
        public Task<List<BucketItem>> GetThePurchasesForEachPresentAsync(int presentId);
        public Task<List<Present>> SortByTheMostPurchasedPresentAsync();
        public Task<List<Present>> SortByTheMostExpensivePresentAsync();
        public Task<List<BucketItem>> GetCartsByUserId(int userId);
    }
}
