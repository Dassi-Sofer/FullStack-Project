using Microsoft.Extensions.Diagnostics.HealthChecks;
using WebProject.DAL;
using WebProject.Models;
using System.Linq;
using System.Net.Sockets;

namespace WebProject.DAL
{
    public class PresentDal:IPresentDal
    {
        private readonly PresentContext _presentContext;
        public PresentDal(PresentContext presentContext)
        {
            this._presentContext = presentContext ?? throw new ArgumentNullException(nameof(presentContext));
        }

        public async Task<int> DeleteAsync(int id)
        {
            var p = _presentContext.Present.Find(id);
            if (p.Quentity > 0)
                return -1;
            _presentContext.Remove(p);
            await _presentContext.SaveChangesAsync();
            return id;

        }

        public async Task<List<Present>> GetAsync()
        {
            List<Present> presents = await _presentContext.Present.ToListAsync();
            foreach (var item in presents)
            {
                item.Donor = await _presentContext.Donor.Where(i => i.Id == item.DonorId).FirstOrDefaultAsync();

            }
            return presents;
        }

      
        public async Task<List<Present>> SortAsync(string? max, string? maxPurches)
        {
            try
            {
                var query = _presentContext.Present.AsQueryable();

                if (max != null)
                {
                    query = query.OrderBy(c => c.Cost);
                }

                if (maxPurches != null)
                {
                    query = query.OrderBy(c => c.Quentity);
                }

                List<Present> presents = await query.ToListAsync();
                return presents;
            }
            catch (Exception e)
            {
                throw new Exception("Error in sorting: " + e.Message);
            }
        }

        public async Task<List<Present>> UserSortAsync(bool? max, bool? category)
        {
            try
            {
                var query = _presentContext.Present.AsQueryable();

                if (max == true)
                {
                    query = query.OrderBy(c => c.Cost);
                }

                if (category == true)
                {
                    query = query.OrderBy(c => c.Category);
                }

                List<Present> presents = await query.ToListAsync();
                return presents;
            }
            catch (Exception e)
            {
                throw new Exception("Error in sorting: " + e.Message);
            }
        }

        public async Task<Present> GetByIdAsync(int id)
        {
            return await _presentContext.Present.FindAsync(id);
        }

        public async Task<Present> PostAsync(Present present)
        {
             _presentContext.Present.Add(present);
            await _presentContext.SaveChangesAsync();
            return present;
        }

        public async Task<Present> PutAsync(Present present)
        {
            Present pr = await _presentContext.Present.FirstOrDefaultAsync(item => item.Id == present.Id);
            if (pr != null)
            {
                pr.Name = present.Name;
                pr.DonorId = present.DonorId;
                pr.Cost = present.Cost;
                pr.Image = present.Image;
                _presentContext.Present.Update(pr);

                await _presentContext.SaveChangesAsync();

                return present;
            }
             return null;
            

        }
    }
}
