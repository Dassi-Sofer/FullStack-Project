
using AutoMapper;
using WebProject.Models;

namespace WebProject.DAL
{
    public class BitemDal : IBItemDal
    {
        private readonly PresentContext _presentContext;
        private readonly ILogger<BucketItem> _logger;
        private readonly IMapper _mapper;

        public BitemDal(PresentContext presentContext, ILogger<BucketItem> logger, IMapper mapper)
        {
            this._presentContext = presentContext;
            this._logger = logger;
            this._mapper = mapper;
        }

        public async Task<int> AddPresentToCartAsync(BucketItem present)
        {
            try
            {

                Bucket order = await _presentContext.Bucket.FirstOrDefaultAsync(o => o.Id == present.BucketId);
                Present p = await _presentContext.Present.FirstOrDefaultAsync(p => p.Id == present.PresentId);
                if (p.isRuffled == true)
                    return -1;
                order.Sum = order.Sum + p.Cost;

                List<BucketItem> bitem = await _presentContext.BucketItem.Where(o => o.BucketId == present.BucketId && o.PresentId == present.PresentId).ToListAsync();
                var item = bitem.FirstOrDefault(i => i.Status == false);
                if (item != null)
                {
                    item.Quantity++;
                    await _presentContext.SaveChangesAsync();
                }
                else
                {
                    await _presentContext.BucketItem.AddAsync(present);
                    await _presentContext.SaveChangesAsync();
                }
                return present.Id;
            }

            catch (Exception ex)
            {
                _logger.LogError("Logging from cart, the exception: " + ex.Message, 1);
                throw new Exception("Logging from cart, the exception: " + ex.Message);
            }

        }

        public async Task<List<BucketItem>> GetCartsByUserId(int userId)
        {
            Bucket bucket = await _presentContext.Bucket.FirstOrDefaultAsync(b => b.UserId == userId);
            List<BucketItem> presents = await _presentContext.BucketItem.Where(i => i.BucketId == bucket.Id).ToListAsync();
            foreach (var item in presents)
            {
                item.Present = await _presentContext.Present.Where(i => i.Id == item.PresentId).FirstOrDefaultAsync();

            }
            return presents;
        }

        public async Task<int> DeletePresentFromCartAsync(int opId)
        {
            try
            {
                BucketItem po = await _presentContext.BucketItem.FirstOrDefaultAsync(po => po.Id == opId);
                if (po != null)
                {
                    if (po.Status == false)
                    {
                        Bucket order = await _presentContext.Bucket.FirstOrDefaultAsync(o => o.Id == po.BucketId);
                        var p = await _presentContext.Present.FirstOrDefaultAsync(p => p.Id == po.PresentId);
                        order.Sum = order.Sum - p.Cost;

                        BucketItem item = await _presentContext.BucketItem.FirstOrDefaultAsync(o => o.Id == po.Id && o.PresentId == po.PresentId);
                        if (item != null)
                        {
                            if (item.Quantity == 1)
                                _presentContext.BucketItem.Remove(po);
                            else
                                item.Quantity--;
                            await _presentContext.SaveChangesAsync();
                            return opId;

                        }
                        else
                            return -1;
                    }
                    else
                        return -1;
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                _logger.LogError("Logging from presentsOrder, the exception: " + ex.Message, 1);
                throw new Exception("Logging from presentsOrder, the exception: " + ex.Message);
            }
        }

        public async Task<List<BucketItem>> GetPresentsOrderAsync()
        {
            //return await _saleContext.PresentsOrder.Where(po=> po.IsDraft == true).ToListAsync();
            return await _presentContext.BucketItem.ToListAsync();
        }

        public async Task<List<BucketItem>> GetThePurchasesForEachPresentAsync(int presentId)
        {
            var presents = _presentContext.BucketItem.Where(po => po.PresentId == presentId);
            return presents.ToList();
        }

        public Task<List<Present>> SortByTheMostExpensivePresentAsync()
        {
            var q = _presentContext.Present.OrderByDescending(p => p.Cost);
            return q.ToListAsync();
        }

        public async Task<List<Present>> SortByTheMostPurchasedPresentAsync()
        {

            var presents = await _presentContext.BucketItem
                          .Include(po => po.Present)
                          .Where(po => po.Status == true)
                          .GroupBy(po => po.Present.Id)
                          .OrderByDescending(po => po.Count())
                          .Select(po => po.First().Present)
                          .ToListAsync();
            return presents;
        }

    }
}
