using WebProject.Models;

namespace WebProject.BL
{
    public interface IRuffleService
    {
        Task<User> Random(int presentId);
        Task<List<Winner>> GetAsync();
        Task<User> GetById(int presentId);
        Task<int> GetTotalSum();

    }
}
