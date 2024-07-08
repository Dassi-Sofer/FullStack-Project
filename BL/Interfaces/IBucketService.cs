

using WebProject.Models;

namespace WebProject.BL
{
    public interface IBucketService
    {
        public Task<int> AddCart(int userId);
        public Task<int> DeleteCart(int id);
        public Task<Bucket> GetCart(int userId);
        public Task<List<User>> GetPurchacersDetails();
        public Task<int> Pay(int userId);
        public Task<int> GetSumOfCarts();
    }
}
