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
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _serviceManager.productService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto dto)
        {
            var result = _mapper.Map<Product>(dto);

            _serviceManager.productService.Add(result);

            return Ok("Ürün eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _serviceManager.productService.Delete(id);
            return Ok("Ürün silindi.");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto dto)
        {
            var result = _mapper.Map<Product>(dto);
            _serviceManager.productService.Update(result);
            return Ok("Ürün güncellendi");
        }
        [HttpGet("{id}")]
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
    }
}
