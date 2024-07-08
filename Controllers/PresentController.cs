using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebProject.BL;
using WebProject.DAL;
using WebProject.DTO;
using WebProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentController : ControllerBase
    {
        private readonly IPresent _presentService;
        private readonly IMapper _mapper;
        public PresentController(IPresent presentService, IMapper mapper)
        {
            this._presentService = presentService ?? throw new ArgumentNullException(nameof(presentService));
            this._mapper = mapper;
        }
        [HttpGet]
        public Task<List<Present>> GetGifts()
        {
            return _presentService.GetPresents();
        }

        [Route("Sort")]
        [HttpGet]
        public async Task<List<Present>> UserSortAsync(bool? max, bool? category)
        {
            return await _presentService.UserSortAsync(max, category);
        }

        [HttpGet("{id}")]
        public async Task<Present> GetGiftByCode(int id)
        {
            return await _presentService.GetPresentById(id);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<bool> AddGiftAsync([FromBody] PresentDTO presentDto)
        {
            var present = _mapper.Map<Present>(presentDto);
            return await _presentService.AddPresent(present);
        }

        [HttpPut]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<bool>> UpdateGift( PresentDTO presentDto)
        {
            try 
            { 
                var present = _mapper.Map<Present>(presentDto);
                if(ModelState.IsValid)
                return await _presentService.PutPresent(present);
                return false;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        // DELETE api/<PresentController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<bool>> DeleteGift(int id)
        {
            try
            {
                return await _presentService.DeletePresent(id);
            }
            
            catch
            {
                return NotFound();
            }
        }
    }
}
