using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebProject.DAL;
using WebProject.DTO;
using WebProject.Models;

namespace WebProject.BL
{
    public class UserServise : IUserService
    {
        private readonly IUserDal _userDal;
        public UserServise(IUserDal userDal)
        {
            this._userDal = userDal ?? throw new ArgumentNullException(nameof(userDal));
        }
        public async Task<List<User>> GetUsers()
        {
            return await _userDal.GetAsync();
        }

        public string Generate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("bd1a1ccf8095037f361a4d351e7c0de65f0776bfc2f478ea8d312c763bb6caca");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                 new Claim(ClaimTypes.Role, user.Role.ToString()),
                 new Claim("userId",user.Id.ToString())

            }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = "http://localhost:7024/",
                Audience = "http://localhost:4200/",

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            //return user.Role+tokenString;
            return tokenString;

        }

        public async Task<User> GetUserById(UserDTO userDTO)
        {
            return await _userDal.GetByIdAsync(userDTO);

        }
        public async Task<bool> AddUser(User user)
        {
            // add the role to the user
            //using (var scope = app.Services.CreateScope())
            //{
            //    var userManager =
            //        scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            //    string UserName = user.UserName;
            //    int Password = user.Password;
            //    if ( await userManager == FindByPasswordAsync(Password) == null)
            //    {
            //        var user1 = new IdentityUser();
            //        user.Password = Password;
            //        user.UserName = UserName;
            //        userManager.CreateAsync(user1);
            //        userManager.AddToRoleAsync(user, "Admin");

            //    }

            //}
            var ad = (await _userDal.PostAsync(user));
            if (ad != null)
                return true;
            return false;

        }

        public async Task<bool> PutUser(User user)
        {
            var up = (await _userDal.PutAsync(user));
            if (up != null)
                return true;
            return false;

        }

        public async Task<bool> DeleteUser(int id)
        {
            var dl = (await _userDal.DeleteAsync(id));
            if (dl != null)
                return true;
            return false;
        }

        public async Task<List<User>> PurchesByPresentId(int presentId)
        {
            return await _userDal.PurchesByPresentId(presentId);
        }
    }
}
