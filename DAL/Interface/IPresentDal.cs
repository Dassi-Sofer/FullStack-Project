using WebProject.Models;

namespace WebProject.DAL
{
    public interface IPresentDal
    {
        Task<List<Present>> GetAsync();
        Task<Present> GetByIdAsync(int id);
        Task<Present> PostAsync(Present present);
        Task<Present> PutAsync(Present present);
        Task<int> DeleteAsync(int id);
        Task<List<Present>> SortAsync(string? max, string? maxPurches);
        Task<List<Present>> UserSortAsync(bool? max, bool? category);

    }
}
