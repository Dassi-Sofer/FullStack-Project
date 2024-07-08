using WebProject.DTO;
using WebProject.Models;

namespace WebProject.DAL
{
    public interface IUserDal
    {
        Task<List<User>> GetAsync();
        Task<User> GetByIdAsync(UserDTO userDTO);
        Task<User> PostAsync(User user);
        Task<User> PutAsync(User user);
        Task<int> DeleteAsync(int id);
        Task<List<User>> PurchesByPresentId(int presentId);

    }
}
