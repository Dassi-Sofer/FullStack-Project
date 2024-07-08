using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebProject.BL;
using WebProject.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuffleController : ControllerBase
    {
        private readonly IRuffleService _ruffleService;
        public RuffleController(IRuffleService ruffleService)
        {
            this._ruffleService = ruffleService ?? throw new ArgumentNullException(nameof(ruffleService));
        }

        // GET: api/<RuffleController>
        [HttpGet]
        [Route("GetWinners")]
        public async Task<List<Winner>> GetWinners()
        {
            return await _ruffleService.GetAsync();
        }

        // GET api/<RuffleController>/5
        [HttpGet]
        [Route("GetWinnerByPresentId")]
        public async Task<User> GetWinnerBypresent(int presentId)
        {
            return await _ruffleService.GetById(presentId);
        }

        // POST api/<RuffleController>
        [HttpPost]
        [Route("ruffledddddddddd")]
       [Authorize(Roles = "Admin")]
        public async Task<User> Random(int presentId)
        {
            return await _ruffleService.Random(presentId);
        }

        [Route("TotalSum")]
        [HttpGet]
        
        public async Task<int> GetTotalSum()
        {
            return await _ruffleService.GetTotalSum();
        }

    }
}
