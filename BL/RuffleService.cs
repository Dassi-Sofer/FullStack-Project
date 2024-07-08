
using WebProject.DAL;
using WebProject.Models;

namespace WebProject.BL
{
    public class RuffleService : IRuffleService
    {
        private readonly IRuffleDal _ruffleDal;
        public RuffleService(IRuffleDal ruffleDal)
        {
            this._ruffleDal = ruffleDal ?? throw new ArgumentNullException(nameof(ruffleDal));
        }

        public async Task<List<Winner>> GetAsync()
        {
            return await _ruffleDal.GetAsync();
        }

        public async Task<User> GetById(int presentId)
        {
            return await _ruffleDal.GetById(presentId);
        }

        public async Task<int> GetTotalSum()
        {
            return await _ruffleDal.GetTotalSum();
        }

        public async Task<User> Random(int presentId)
        {
            return await _ruffleDal.Random(presentId);
        }
    }
}
