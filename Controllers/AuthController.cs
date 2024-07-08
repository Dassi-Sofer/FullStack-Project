
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.CodeDom.Compiler;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebProject.BL;
using WebProject.DTO;
using WebProject.Models;
using WebProject.DAL;
using WebProject.DTO;
using WebProject.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.CodeDom.Compiler;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebProject.DTO;

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginController(IConfiguration config, IUserService userService,IMapper mapper)
        {
            _config = config;

            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._userService = userService ?? throw new ArgumentNullException(nameof(userService));

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> Login(UserDTO userLogin)
        {
            try
            {
                User user = await _userService.GetUserById(userLogin);

                if (user != null)
                {
                    var token = _userService.Generate(user);
                    var jsonToken = JsonConvert.SerializeObject(new { token });
                    return jsonToken;

                }

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

    }
}

