using CashViewer_backend.BAL.Services;
using CashViewer_backend.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashViewer_backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        private readonly ServiceShop _serviceShop;
        public ShopController(ILogger<ShopController> logger, ServiceShop serviceShop)
        {
            _logger = logger;
            _serviceShop = serviceShop;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_serviceShop.GetAllShops());
        }
        [HttpGet]
        [Route("details")]
        public IActionResult GetShopById(int id)
        {
            try
            {
                var shop = _serviceShop.GetShopById(id);
                return Ok(shop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("createshop")]
        public IActionResult AddShop(Shop shop)
        {
            var shops = _serviceShop.GetAllShops();
            if (shops.SingleOrDefault(x => x.Name == shop.Name) == null)
            {
                try
                {
                    _serviceShop.AddShop(shop);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            } else
            {
                return BadRequest("This shop is already added");
            }
        }
        [HttpDelete]
        [Route("removeshop")]
        public IActionResult RemoveShop(int id)
        {
            try
            {
                _serviceShop.RemoveShopById(id);
                return Ok();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("editshop")]
        public IActionResult UpdateShop(Shop shop)
        {
            try
            {
                _serviceShop.UpdateShop(shop);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
