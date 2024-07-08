using WebProject.DTO;
using WebProject.Models;

namespace WebProject.BL
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(UserDTO userDTO);
        Task<bool> AddUser(User user);
        Task<bool> PutUser(User user);
        Task<bool> DeleteUser(int id);
        Task<List<User>> PurchesByPresentId(int presentId);
        public string Generate(User user);

    }
}
