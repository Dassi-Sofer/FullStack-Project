using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebProject.BL;
using WebProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketController : ControllerBase
    {
        private readonly IBucketService _bucketService;
        private readonly IMapper _mapper;


        public BucketController(IBucketService bucketService, IMapper mapper)
        {
            this._bucketService = bucketService;
            this._mapper = mapper;
        } 

        [HttpPost]
        [Route("AddCart")]
        public async Task<ActionResult<int>> AddCart()
        {
            try
            {
                //int userId1 = (int)HttpContext.Request.HttpContext.Items["User"];
                var user = User.Claims.FirstOrDefault(c => c.Type == "userId");
                int.TryParse(user?.Value, out int userId);

                return await _bucketService.AddCart(userId);
                    //return CreatedAtAction("AddCart", new { _order.Id }, order);
                //}
                //return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message + "This error occured from the AddCart function");
            }
        }

        // POST api/<OrderController>
        [HttpGet]
        [Route("GetCart")]
        public async Task<ActionResult<Bucket>> GetCart(int userId)
        {
            try
            {
                 return Ok(await _bucketService.GetCart(userId));
            }
                //return new JsonResult("Something went wrong") { StatusCode = 500 };
            catch (Exception ex)
            {
                return NotFound(ex.Message + "This error occured from the GetCart function");
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete]
        [Route("DeleteCart")]
        public async Task<ActionResult<int>> DeleteCart(int id)
        {
            return await _bucketService.DeleteCart(id);
        }

        [HttpGet]
        [Route("GetPurchacersDetails")]
        public async Task<ActionResult<List<User>>> GetPurchacersDetails()
        {
            try
            {
                 
                //var _res = _mapper.Map<UserRegisterDTO>(res);
                return Ok(await _bucketService.GetPurchacersDetails());
            }
            //return new JsonResult("Something went wrong") { StatusCode = 500 };
            catch (Exception ex)
            {
                return NotFound(ex.Message + "This error occured from the GetPurchacersDetails function");
            }
        }

        [HttpGet]
        [Route("Pay")]
        public async Task<ActionResult<int>> Pay()
        {
            try
            {
                var user = User.Claims.FirstOrDefault(c => c.Type == "userId");
                int.TryParse(user?.Value, out int userId);
                var res =await _bucketService.Pay(userId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message + "This error occured from the Pay function");
            }

        }

        [Route("GetTotalPrice")]
        [HttpGet]
        async public Task<int> GetTotalPrice()
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == "userId");
            int.TryParse(user?.Value, out int userId);
            Bucket selectedPresents = await _bucketService.GetCart(userId);
            return (int)selectedPresents.Sum;
        }

        [Route("GetAllIncomes")]
        [HttpGet]
        async public Task<int> GetAllIncomes()
        {
            return await _bucketService.GetSumOfCarts();
        }
    }
}
