using System.Collections.ObjectModel;
using System.Drawing;
using WebProject.BL;
using WebProject.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebProject.DAL
{
    public class DonorDal:IDonorDal
    {
        private readonly PresentContext _presentContextDal;
        private readonly ILogger<Donor> _logger;
        public DonorDal(PresentContext presentContextDal, ILogger<Donor> logger)
        {
            this._presentContextDal = presentContextDal ?? throw new ArgumentNullException(nameof(presentContextDal));
            this._logger = logger;
        }
        
        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                _presentContextDal.Remove(_presentContextDal.Donor.Find(id));
                await _presentContextDal.SaveChangesAsync();
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Logging from donor, the exception: " + ex.Message, 1);
                throw new Exception("Logging from donor, the exception: " + ex.Message);
            }

        }
        
        public async Task<List<Donor>> GetAsync()
        {
            try
            {
            return _presentContextDal.Donor.ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError("Logging from donor, the exception: " + ex.Message, 1);
                throw new Exception("Logging from donor, the exception: " + ex.Message);
            }
        }
        
        public async Task<Donor> GetByIdAsync(int id)
        {
            try
            {
                return await _presentContextDal.Donor.FindAsync(id);

            }
            catch (Exception ex)
            {
                _logger.LogError("Logging from donor, the exception: " + ex.Message, 1);
                throw new Exception("Logging from donor, the exception: " + ex.Message);
            }
        }


        public async Task<List<Donor>> GetSpecificDonor(string? name, string? email, string? present)
        {
            try
            {
                var sinun = _presentContextDal.Donor.Where(donor => (name == null ? true : donor.Name.Contains(name))
                                                            && (email == null ? true : donor.Email.Contains(email)))
                    .Join(_presentContextDal.Present,
                        donor => donor.Id,
                        present => present.DonorId,
                        (donor, present) => new { Donor = donor, Present = present })
                    .Where(x => present == null ? true : x.Present.Name.Contains(present))
                    .Select(x => x.Donor);

                List<Donor> donors = await sinun.ToListAsync();
                return donors;
            }
            catch (Exception e)
            {
                _logger.LogError("Error from donor: " + e.Message, 1);
                throw new Exception("Error from donor: " + e.Message);
            }
        }


        public async Task<Donor> PostAsync(Donor donor)
        {
            try
            {
            _presentContextDal.Donor.Add(donor);
            await _presentContextDal.SaveChangesAsync();
            return donor;
            }
            catch (Exception ex)
            {
                _logger.LogError("Logging from donor, the exception: " + ex.Message, 1);
                throw new Exception("Logging from donor, the exception: " + ex.Message);
            }

        }
        public async Task<bool> PutAsync(Donor donor)
        {
            try
            {
                Donor donorToEdit = await _presentContextDal.Donor.FirstOrDefaultAsync(d => d.Id == donor.Id);
                if (donorToEdit != null)
                {
                    donorToEdit.Name = donor.Name;
                    donorToEdit.Address = donor.Address;
                    donorToEdit.Email = donor.Email;
                    _presentContextDal.Donor.Update(donorToEdit);
                    await _presentContextDal.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError("Logging from donor, the exception: " + ex.Message, 1);
                throw new Exception("Logging from donor, the exception: " + ex.Message);
            }

        }

        public async Task<List<Present>> GetDonationListAsync(int id)
        {
            var presents = await _presentContextDal.Present.Where(p => p.DonorId == id).ToListAsync();
            return presents;
        }
    }
}
