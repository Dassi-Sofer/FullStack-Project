
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Hosting;
using System.Runtime.InteropServices;
using WebProject.DAL;
using WebProject.Models;

namespace WebProject.DAL
{
        public class RuffleDal : IRuffleDal
    {
            private readonly PresentContext _presentContext;
            public RuffleDal(PresentContext presentContext)
            {
                this._presentContext = presentContext ?? throw new ArgumentNullException(nameof(presentContext));
            }

        public async Task<List<Winner>> GetAsync()
        {
            var winners = await _presentContext.Winner.ToListAsync();
           
            foreach (var w in winners)
            {
                w.Present = _presentContext.Present.FirstOrDefault(p => p.Id == w.PresentId);
                w.User = _presentContext.User.FirstOrDefault(u => u.Id == w.UserId);
            }
            return winners;
        }

        public async Task<User> GetById(int presentId)
        {
            var w = _presentContext.Winner.FirstOrDefault(w => w.PresentId == presentId);
            if (w == null)
                return null;
           return _presentContext.User.FirstOrDefault(u => u.Id == w.UserId); 
        }

        public async Task<int> GetTotalSum()
        {
            int count = 0;
            var bi = _presentContext.BucketItem.Where(bi => bi.Status == true);
            foreach (var b in bi)
            {
                var a = (_presentContext.Present.FirstOrDefault(p => p.Id == b.PresentId));
                count += a.Cost;
            }
            return count;
        }

        //ההגרלה
        public async Task<User> Random(int presentId)
        {
            var prs = _presentContext.Present.Find(presentId);
            if (prs.isRuffled == false)
            {
                List<BucketItem> my_list = await _presentContext.BucketItem
                    .Where(bi => bi.Status == true && bi.PresentId == presentId)
                    .ToListAsync();
                Random random = new Random();
                int i = random.Next(0, my_list.Count);
                var b_item_win = my_list[i];
                var wb = b_item_win.BucketId;

                var b_winner = await _presentContext.Bucket
                    .FirstOrDefaultAsync(b => b.Id == wb);
                var winner = await _presentContext.User
                    .FirstOrDefaultAsync(b => b.Id == b_winner.UserId);
                Winner my_winner = new Winner();
                my_winner.UserId = winner.Id;
                my_winner.PresentId = presentId;
                prs.isRuffled = true;
                _presentContext.Present.Update(prs);
                _presentContext.Winner.Add(my_winner);
                await _presentContext.SaveChangesAsync();
                return winner;
            }
            return  await GetById(presentId);
        }

    }
}
