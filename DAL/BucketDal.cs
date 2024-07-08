
using Microsoft.Extensions.Hosting;
using WebProject.Models;

namespace WebProject.DAL
{
    public class BucketDal : IBucketDal
    {
        private readonly PresentContext _presentContextDal;
        private readonly ILogger<Bucket> _logger;

        public BucketDal(PresentContext presentContext, ILogger<Bucket> logger)
        {
            _presentContextDal = presentContext;
            _logger = logger;
        }

        public async Task<int> AddCartAsync(int userId)
        {
            try
            {
                var order = await _presentContextDal.Bucket.FirstOrDefaultAsync(o => o.UserId == userId);
                if (order == null)
                {
                    Bucket o = new Bucket();
                    o.UserId = userId;
                    o.Sum = 0;
                    o.OrderDate = DateTime.Now;
                    await _presentContextDal.Bucket.AddAsync(o);
                    await _presentContextDal.SaveChangesAsync();
                    return o.Id;
                }
                return order.Id;
            }

            catch (Exception ex)
            {
                _logger.LogError("Logging from order, the exception: " + ex.Message, 1);
                throw new Exception("Logging from order, the exception: " + ex.Message);
            }
        }

        public async Task<int> DeleteCartAsync(int userId)
        {
            try
            {
                var order = await _presentContextDal.Bucket.FirstOrDefaultAsync(o => o.UserId == userId);
                _presentContextDal.Remove(order);
                await _presentContextDal.SaveChangesAsync();
                return order.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Logging from order, the exception: " + ex.Message, 1);
                throw new Exception("Logging from order, the exception: " + ex.Message);
            }
        }

        public async Task<Bucket> GetCartAsync(int userId)
        {
            //var query = _saleContext.Order.Include(o => _saleContext.PresentsOrder.Where(po => po.OrderId == o.Id));
            var q = await _presentContextDal.Bucket.FirstOrDefaultAsync(o => o.UserId == userId);
            return q;
        }

        public async Task<List<User>> GetPurchacersDetailsAsync()
        {
            var purchasersInclude = _presentContextDal.Bucket.Include(o => o.User);
            var q = purchasersInclude.Select(o => o.User);
            return q.ToList();
        }

        public async Task<int> PayAsync(int userId)
        {
            {
                try
                {
                    var order = await _presentContextDal.Bucket.FirstOrDefaultAsync(o => o.UserId == userId);
                    if (order != null)
                    {
                        order.Sum = 0;
                        _presentContextDal.Bucket.Update(order);
                        var q = await _presentContextDal.BucketItem.Where(po => po.BucketId == order.Id).ToListAsync();
                        for (var i = 0; i < q.Count(); i++)
                        {
                            var p = await _presentContextDal.Present.FirstOrDefaultAsync(p => p.Id == q[i].PresentId);
                            p.Quentity = (int)q[i].Quantity;
                            _presentContextDal.Present.Update(p);
                            q[i].Status = true;
                            _presentContextDal.BucketItem.Update(q[i]);
                        }

                        _presentContextDal.SaveChangesAsync();

                        return (int)order.Sum;
                    }
                    return -1;
                }

                catch (Exception ex)
                {
                    _logger.LogError("Logging from order, the exception: " + ex.Message, 1);
                    throw new Exception("Logging from order, the exception: " + ex.Message);
                }
            }
        }
        public async Task<int> GetSumOfCarts()
        {
            int sum = 0;
            var bitems = await _presentContextDal.BucketItem.Where(b => b.Status == true).ToListAsync();
            var price = _presentContextDal.BucketItem.Include(bi => bi.Present).Where(bi => bi.Present.Id == bi.PresentId)
                .Select(p => p.Present.Cost);
            foreach (var item in bitems)
            {
               sum+= _presentContextDal.Present.FirstOrDefault(p => p.Id == item.PresentId).Cost*(int)item.Quantity ;
            }

            return sum;
        }
    }
}
