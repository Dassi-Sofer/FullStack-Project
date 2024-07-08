using WebProject.Models;

namespace WebProject.BL
{
    public interface IPresent
    {
        Task<List<Present>> GetPresents();
        Task<Present> GetPresentById( int id);
        Task<bool> AddPresent(Present present);
        Task<bool> PutPresent(Present present);
        Task<bool> DeletePresent(int id);
        Task<List<Present>> UserSortAsync(bool? max, bool? category);
    }
}
