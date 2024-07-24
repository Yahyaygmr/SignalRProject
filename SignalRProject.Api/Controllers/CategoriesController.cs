using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.DtoLayer.CategoryDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BasesController
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _serviceManager.categoryService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto dto)
        {
            var result = _mapper.Map<Category>(dto);

            _serviceManager.categoryService.Add(result);

            return Ok("Kategori eklendi.");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _serviceManager.categoryService.Delete(id);
            return Ok("Kategori silindi.");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto dto)
        {
            var result = _mapper.Map<Category>(dto);
            _serviceManager.categoryService.Update(result);
            return Ok("Kategori güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _serviceManager.categoryService.GetById(id);
            return Ok(value);
        }
    }
}
