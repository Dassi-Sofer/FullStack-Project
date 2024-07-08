
using WebProject.DAL;
using WebProject.Models;

namespace WebProject.BL
{
    public class BucketService : IBucketService
    {


        private readonly IBucketDal _BucketDal;
        private readonly ILogger<Bucket> _logger;
  
        public BucketService(IBucketDal bucketDal, ILogger<Bucket> logger)
        {
            _BucketDal = bucketDal;
            _logger = logger;
        }
        public async Task<int> AddCart(int userId)
        {
            return await _BucketDal.AddCartAsync(userId);
        }

        public async Task<int> DeleteCart(int id)
        {
            return await _BucketDal.DeleteCartAsync(id);
        }

        public async Task<Bucket> GetCart(int userId)
        {
            return await _BucketDal.GetCartAsync(userId);
        }

        public async Task<List<User>> GetPurchacersDetails()
        {
            return await _BucketDal.GetPurchacersDetailsAsync();
        }

        public async Task<int> GetSumOfCarts()
        {
            return await _BucketDal.GetSumOfCarts();        
                
        }

        public Task<int> Pay(int userId)
        {
            return _BucketDal.PayAsync(userId);
        }
    }
}


