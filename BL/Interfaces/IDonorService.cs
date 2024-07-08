using WebProject.Models;

namespace WebProject.BL
{
    public interface IDonorService
    {
        Task<List<Donor>> GetDonors(string? name, string? email, string? present);
        Task<Donor> GetDonorById(int id);
        Task<bool> AddDonor(Donor donor);
        Task<bool> PutDonor(Donor donor);
        Task<bool> DeleteDonor(int id);
        Task<List<Present>> GetDonationList(int id);
        //Task<List<Donor>> GetSpecDonor(string? name, string? email);

    }
}
