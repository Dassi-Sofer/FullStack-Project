
using WebProject.DAL;
using WebProject.Models;

namespace WebProject.BL
{
    public class PresentService : IPresent
    {
        private readonly IPresentDal _presentDal;
        public PresentService(IPresentDal presentDal)
        {
            this._presentDal = presentDal ?? throw new ArgumentNullException(nameof(presentDal));
        }
        public async Task<List<Present>> GetPresents()
        {
            return await _presentDal.GetAsync();
        }
        public async Task<Present> GetPresentById(int id)
        {
            return await _presentDal.GetByIdAsync(id);
            
        }
        public async Task<bool> AddPresent(Present present)
        {
             var ad= (await _presentDal.PostAsync(present));
            if (ad != null)
                return true;
            return false;
           
        }
        
             public async Task<bool> PutPresent(Present present)
        {
            var up= await _presentDal.PutAsync(present);
            if (up != null)
                return true;
            return false;

        }

        public async Task<bool> DeletePresent(int id)
        {
            var dl= ( await _presentDal.DeleteAsync(id));
            if (dl != null)
                return true;
            return false;
        }

        public async  Task<List<Present>> UserSortAsync(bool? max, bool? category)
        {
            return await _presentDal.UserSortAsync(max,category);
        }
    }
}
