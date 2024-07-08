using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using System.Reflection.Metadata.Ecma335;
using WebProject.BL;
using WebProject.DTO;
using WebProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bItemController : ControllerBase
    {
        private readonly IBucketItemService _bItemService;
        private readonly IMapper _mapper;
        public bItemController(IBucketItemService bItemService, IMapper mapper)
        {
            this._bItemService = bItemService;
            this._mapper = mapper;
        }

        // GET: api/<PresentsOrderController>
        [HttpGet]
        [Route("GetPresentsOrder")]
        public async Task<ActionResult<List<BucketItemDTO>>> GetPresentsOrder()
        {
            try
            {
                var allPo = await _bItemService.GetPresentsOrder();
                var _AllPo = _mapper.Map<List<BucketItem>>(allPo);
                return Ok(_AllPo);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message + "This error occured from the GetPresentsOrder function");
            }
        }

        // POST api/<PresentsOrderController>
        [HttpPost]
        [Route("AddPresentToCart")]
        public async Task<ActionResult<int>> AddPresentToCart(BucketItemDTO present)
        {
            try
            {
                var _present = _mapper.Map<BucketItem>(present);
                return await _bItemService.AddPresentToCart(_present);
            }
            catch
            {
                return NoContent();
            }
        }

        // DELETE api/<PresentsOrderController>/5
        [HttpDelete]
        [Route("DeletePresentFromCart")]
        public async Task<ActionResult<int>> DeletePresentFromCart(int opId)
        {
            try
            {
                var res = await _bItemService.DeletePresentFromCart(opId);
                if (res !=-1)
                    return Ok(res);
                else
                    return new JsonResult("You can delete present after its paid") { StatusCode = 500 };

            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetCartsByUserId")]
        public async Task<ActionResult<List<BucketItem>>> GetCartsByUserId()
        {
            try
            {
                var user = User.Claims.FirstOrDefault(c => c.Type == "userId");
                int.TryParse(user?.Value, out int userId);
                var res = await _bItemService.GetCartsByUserId(userId);
                if (res != null)
                    return Ok(res);
                else
                    return new JsonResult("You can delete present after its paid") { StatusCode = 500 };

            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet]
            [Route("GetThePurchasesForEachPresent")]
            public async Task<ActionResult<List<BucketItemDTO>>> GetThePurchasesForEachPresent(int presentId)
            {
                try
                {
                    var PoForPresent = await _bItemService.GetThePurchasesForEachPresent(presentId);
                    var _PoForPresent = _mapper.Map<List<BucketItem>>(PoForPresent);
                    return Ok(_PoForPresent);
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message + "This error occured from the GetThePurchasesForEachPresent function");
                }
            }

            [HttpGet]
            [Route("SortByTheMostPurchasedPresent")]
            public async Task<ActionResult<List<PresentDTO>>> SortByTheMostPurchasedPresent()
            {
                try
                {
                    var res = await _bItemService.SortByTheMostPurchasedPresent();
                    var _res = _mapper.Map<List<PresentDTO>>(res);
                    return Ok(_res);
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message + "This error occured from the SortByTheMostPurchasedPresent function");
                }
            }

            [HttpGet]
            [Route("SortByTheMostExpensivePresent")]
            public async Task<ActionResult<List<PresentDTO>>> SortByTheMostExpensivePresent()
            {
                try
                {
                    var res = await _bItemService.SortByTheMostExpensivePresent();
                    var _res = _mapper.Map<List<PresentDTO>>(res);
                    return Ok(_res);
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message + "This error occured from the SortByTheMostExpensivePresent function");
                }
            }
    }
    }

