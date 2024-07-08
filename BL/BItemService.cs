

using WebProject.DAL;
using WebProject.Models;

namespace WebProject.BL
{
    public class BucketItemService : IBucketItemService
    {
        private readonly IBItemDal _BucketItemDal;
        private readonly ILogger<BucketItem> _logger;

        public BucketItemService(IBItemDal BucketItemDal, ILogger<BucketItem> logger)
        {
            this._BucketItemDal = BucketItemDal;

        }
        public async Task<List<BucketItem>> GetCartsByUserId(int userId)
        {
            return await _BucketItemDal.GetCartsByUserId(userId);
        }

        public async Task<int> AddPresentToCart(BucketItem present)
        {
            return await _BucketItemDal.AddPresentToCartAsync(present);
        }

        public  async Task<int> DeletePresentFromCart(int opId)
        {
            return await _BucketItemDal.DeletePresentFromCartAsync(opId);
        }

        public async Task<List<BucketItem>> GetPresentsOrder()
        {
            return await _BucketItemDal.GetPresentsOrderAsync();
        }

        public async Task<List<BucketItem>> GetThePurchasesForEachPresent(int presentId)
        {
            return await _BucketItemDal.GetThePurchasesForEachPresentAsync(presentId);
        }

        public async Task<List<Present>> SortByTheMostExpensivePresent()
        {
            return await _BucketItemDal.SortByTheMostExpensivePresentAsync();
        }

        public  Task<List<Present>> SortByTheMostPurchasedPresent()
        {
            return _BucketItemDal.SortByTheMostPurchasedPresentAsync();
        }
    }

}