using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebProject.BL;
using WebProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;
        public DonorController(IDonorService donorService)
        {
            this._donorService = donorService ?? throw new ArgumentNullException(nameof(donorService));
        }
        // GET: api/<PresentController>
        [HttpGet]
       [Authorize(Roles ="Admin")]
        public async Task<List<Donor>> GetDonators(string? name, string? email, string? present)
        {
            return await _donorService.GetDonors(name, email, present);
        }
       
        [HttpGet()]
        [Route("GetById")]

        [Authorize(Roles = "Admin")]
        public async Task<Donor> GetDonatorById(int id)
        {
            return await _donorService.GetDonorById(id);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<bool> AddDonator([FromBody] Donor donor)
        {
            return await _donorService.AddDonor(donor);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<bool> UpdateDonator([FromBody] Donor donor)
        {
            return await _donorService.PutDonor(donor);

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> DeleteDonator(int id)
        {
            return await _donorService.DeleteDonor(id);
        }

        [HttpGet]
        [Route("GetDonationList")]
        public async Task<ActionResult<List<Present>>> GetDonationList(int id)
        {
            try
            {
                return Ok(await _donorService.GetDonationList(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message + "This error occured from the GetDonationList function");
            }
        }
    }
}
