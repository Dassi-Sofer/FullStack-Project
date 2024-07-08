using WebProject.Models;

namespace WebProject.DAL
{
    public interface IDonorDal
    {
        Task<List<Donor>> GetAsync();
        Task<Donor> GetByIdAsync(int id);
        Task<Donor> PostAsync(Donor donor);
        Task<bool> PutAsync(Donor donor);
        Task<int> DeleteAsync(int id);
        Task<List<Donor>> GetSpecificDonor(string? name, string? email, string? present);
        Task<List<Present>> GetDonationListAsync(int id);
    }
}
