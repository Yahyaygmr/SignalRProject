using DynamicConsume;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.CategoryDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Consume<ResultCategoryDto> _resultCategoryConsume;
        private readonly Consume<CreateCategoryDto> _createCategoryConsume;
        private readonly Consume<object> _deleteCategoryConsume;
        private readonly Consume<GetCategoryByIdDto> _getCategoryByIdConsume;
        private readonly Consume<UpdateCategoryDto> _updateCategoryConsume;

        public CategoryController(Consume<ResultCategoryDto> resultCategoryConsume, Consume<CreateCategoryDto> createCategoryConsume, Consume<object> deleteCategoryConsume, Consume<GetCategoryByIdDto> getCategoryByIdConsume, Consume<UpdateCategoryDto> updateCategoryConsume)
        {
            _resultCategoryConsume = resultCategoryConsume;
            _createCategoryConsume = createCategoryConsume;
            _deleteCategoryConsume = deleteCategoryConsume;
            _getCategoryByIdConsume = getCategoryByIdConsume;
            _updateCategoryConsume = updateCategoryConsume;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var categories = await _resultCategoryConsume.GetListAsync("categories/categorylist");

            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            var result = await _createCategoryConsume.PostAsync("categories/createcategory", dto);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Kaydetme işlemi sırasında bir hata oluştu";
                return View(dto);
            }
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _deleteCategoryConsume.DeleteAsync("categories/delete", id);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Silme işlemi sırasında bir hata oluştu";
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public async Task<ActionResult> UpdateCategory(int id)
        {
            var values = await _getCategoryByIdConsume.GetByIdAsync("categories/getcategory", id);
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            var result = await _updateCategoryConsume.PutAsync("categories/updatecategory", dto);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Güncelleme işlemi sırasında bir hata oluştu";
                return RedirectToAction("Index");
            }
        }

    }
}
