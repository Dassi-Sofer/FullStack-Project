

using WebProject.Models;

namespace WebProject.DAL
{
    public interface IBucketDal
    {
        public Task<int> AddCartAsync(int userId);
        public Task<int> DeleteCartAsync(int id);
        public Task<Bucket> GetCartAsync(int userId);
        public Task<List<User>> GetPurchacersDetailsAsync();
        public Task<int> PayAsync(int userId);
        public  Task<int> GetSumOfCarts();
    }
}
