using WebProject.DAL;
using WebProject.DTO;
using WebProject.Models;

namespace WebProject.DAL
{
    public class UserDal:IUserDal
    {
        private readonly PresentContext _presentContext;
        public UserDal(PresentContext presentContext)
        {
            this._presentContext = presentContext ?? throw new ArgumentNullException(nameof(presentContext));
        }

        public async Task<int> DeleteAsync(int id)
        {
            _presentContext.Remove(_presentContext.User.Find(id));
            await _presentContext.SaveChangesAsync();
            return id;

        }

        public async Task<List<User>> GetAsync()
        {
            return _presentContext.User.ToList();
        }



        public async Task<User> GetByIdAsync(UserDTO userDTO)
        {
            User user = _presentContext.User.FirstOrDefault(p => p.Password == userDTO.Password && p.UserName == userDTO.UserName);
            return user;

        }
        public async Task<List<User>> PurchesByPresentId(int presentId)
        {
            //var bitames = _presentContext.BucketItem.Where(bi =>  _presentContext.Bucket.Where(b => b.Id == bi.BucketId););
            ////(bi.PresentId == presentId && bi.Status == true &&

            //var users = new List<User>();
            //foreach (var bi in bitames)
            //{
            //    users.Add(_presentContext.User.FirstOrDefault(u => bi.BucketId == u.BucketId));
            //}
            //return users;
            return null;
           
        }




        public async Task<User> PostAsync(User user)
        {
            _presentContext.User.Add(user);
            await _presentContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> PutAsync(User user)
        {

            _presentContext.User.Update(user);
            await _presentContext.SaveChangesAsync();
            return user;
        }

       
    }
}