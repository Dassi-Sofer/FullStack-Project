using WebProject.DAL;
using WebProject.Models;

namespace WebProject.BL
{
    public class DonorService:IDonorService
    {

        private readonly IDonorDal _donorDal;
        public DonorService(IDonorDal donorDal)
        {
            this._donorDal = donorDal ?? throw new ArgumentNullException(nameof(donorDal));
        }
        public async Task<List<Donor>> GetDonors(string? name, string? email,string? present)
        {
            if (name == null && email == null &&present==null)
                return await _donorDal.GetAsync();
            return await _donorDal.GetSpecificDonor(name, email,present);
        }
        public async Task<Donor> GetDonorById(int id)
        {
            return await _donorDal.GetByIdAsync(id);

        }
        public async Task<bool> AddDonor(Donor donor)
        {
            var ad = (await _donorDal.PostAsync(donor));
            if (ad != null)
                return true;
            return false;

        }

        public async Task<bool> PutDonor(Donor donor)
        {
           return await _donorDal.PutAsync(donor);
            
             

        }

        public async Task<bool> DeleteDonor(int id)
        {
            var dl = (await _donorDal.DeleteAsync(id));
            if (dl != null)
                return true;
            return false;
        }

        public async Task<List<Present>> GetDonationList(int id)
        {
            return await _donorDal.GetDonationListAsync(id);
        }

      
    }
}
