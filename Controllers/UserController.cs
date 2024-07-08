using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using WebProject.BL;
using WebProject.DTO;
using WebProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserService _presentService;
        public UserController(IUserService presentService, IMapper mapper)
        {
            this._presentService = presentService ?? throw new ArgumentNullException(nameof(presentService));
            this.mapper = mapper;
        }
        // GET: api/<PresentController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public Task<List<User>> GetPurcheses()
        {
            return _presentService.GetUsers();
        }

        // POST api/<PresentController>
        [Route("Register")]
        [HttpPost]
        public async Task<bool> AddPurches([FromBody] User user)
        {
            return await _presentService.AddUser(user);
        }

        // PUT api/<PresentController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> UpdatePurches([FromBody] User user)
        {
            return await _presentService.PutUser(user);

        }

        // DELETE api/<PresentController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> DeletePurches(int id)
        {
            return await _presentService.DeleteUser(id);
        }

        [Route("GetPurches")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<List<User>> PurchesByPresentId(int presentId)
        {
            return await _presentService.PurchesByPresentId(presentId);
        }
    }
}
