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
        [HttpGet("CategoryList")]
        public IActionResult CategoryList()
        {
            var values = _serviceManager.categoryService.GetAll();
            return Ok(values);
        }
        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(CreateCategoryDto dto)
        {
            var result = _mapper.Map<Category>(dto);

            _serviceManager.categoryService.Add(result);

            return Ok("Kategori eklendi.");
        }
        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _serviceManager.categoryService.Delete(id);
            return Ok("Kategori silindi.");
        }
        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory(UpdateCategoryDto dto)
        {
            var result = _mapper.Map<Category>(dto);
            _serviceManager.categoryService.Update(result);
            return Ok("Kategori güncellendi");
        }
        [HttpGet("GetCategory/{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _serviceManager.categoryService.GetById(id);
            return Ok(value);
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var values = _serviceManager.categoryService.CategoryCount();
            return Ok(values);
        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            var values = _serviceManager.categoryService.ActiveCategoryCount();
            return Ok(values);
        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            var values = _serviceManager.categoryService.PassiveCategoryCount();
            return Ok(values);
        }
    }
}
