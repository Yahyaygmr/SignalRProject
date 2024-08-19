using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.Api.Models;
using SignalRProject.DtoLayer.BasketDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : BasesController
    {
        [HttpGet("[action]/{id}")]
        public IActionResult GetBasketByMenuTableId(int id)
        {
            var values = _serviceManager.basketService.GetBasketByMenuTableId(id);
            var result = values.Select(x => new ResultBasketListWithProduct
            {
                BasketId = x.BasketId,
                Count = x.Count,
                MenuTableId = x.MenuTableId,
                Price = x.Price,
                ProductId = x.ProductId,
                TotalPrice = x.TotalPrice,
                MenuTableName = x.MenuTable.Name,
                ProductName = x.Product.Name,
                ProductImage = x.Product.ImageUrl,
            }).ToList();
            return Ok(result);
        }
        [HttpPost("[action]")]
        public IActionResult CreateBasket(CreateBasketDto dto)
        {

            var result = _mapper.Map<Basket>(dto);

            result.Count = 1;
            result.MenuTableId = 4;
            result.Price = _serviceManager.productService.EntityTable
                .Where(x => x.ProductId == result.ProductId)
                .Select(x => x.Price)
                .FirstOrDefault();
            result.TotalPrice = 0;

            _serviceManager.basketService.Add(result);

            return Ok(result);
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteBasket(int id)
        {
            _serviceManager.basketService.Delete(id);

            return Ok("Sepetteki Ürün Silindi");
        }

    }
}
