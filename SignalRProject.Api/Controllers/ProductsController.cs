using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.DtoLayer.ProductDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BasesController
    {
        [HttpGet("ProductList")]
        public IActionResult ProductList()
        {
            var values = _serviceManager.productService.GetAll();
            return Ok(values);
        }
        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct(CreateProductDto dto)
        {
            var result = _mapper.Map<Product>(dto);

            _serviceManager.productService.Add(result);

            return Ok("Ürün eklendi.");
        }
        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _serviceManager.productService.Delete(id);
            return Ok("Ürün silindi.");
        }
        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct(UpdateProductDto dto)
        {
            var result = _mapper.Map<Product>(dto);
            _serviceManager.productService.Update(result);
            return Ok("Ürün güncellendi");
        }
        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _serviceManager.productService.GetById(id);
            return Ok(value);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _serviceManager.productService.ListProductsWithCategory();
            return Ok(values);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var values = _serviceManager.productService.EntityTable.Count();
            return Ok(values);
        }

        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByHamburger()
        {
            var values = _serviceManager.productService.EntityTable.Where(x => x.CategoryId == (_serviceManager.categoryService.EntityTable.Where(x => x.Name == "Hamburger").Select(x => x.CategoryId).FirstOrDefault())).Count();
            return Ok(values);
        }

        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByDrink()
        {
            var values = _serviceManager.productService.EntityTable.Where(x=> x.CategoryId == (_serviceManager.categoryService.EntityTable.Where(x=>x.Name == "İçecek").Select(x=>x.CategoryId).FirstOrDefault())).Count();
            return Ok(values);
        }

        [HttpGet("ProductAvgPrice")]
        public IActionResult ProductAvgPrice()
        {
            var values = _serviceManager.productService.EntityTable.Average(x=>x.Price);
            return Ok(values);
        }
    }
}
