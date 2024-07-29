using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.CategoryDtos;
using SignalRProject.WebUI.Dtos.PoductDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly Consume<ResultProductWithCategoryDto> _resultProductConsume;
        private readonly Consume<CreateProductDto> _createProductConsume;
        private readonly Consume<object> _deleteProductConsume;
        private readonly Consume<GetProductByIdDto> _getProductByIdConsume;
        private readonly Consume<UpdateProductDto> _updateProductConsume;
        private readonly Consume<ResultCategoryDto> _resultCategoryConsume;

        public ProductController(Consume<ResultProductWithCategoryDto> resultProductConsume, Consume<CreateProductDto> createProductConsume, Consume<object> deleteProductConsume, Consume<GetProductByIdDto> getProductByIdConsume, Consume<UpdateProductDto> updateProductConsume, Consume<ResultCategoryDto> resultCategoryConsume)
        {
            _resultProductConsume = resultProductConsume;
            _createProductConsume = createProductConsume;
            _deleteProductConsume = deleteProductConsume;
            _getProductByIdConsume = getProductByIdConsume;
            _updateProductConsume = updateProductConsume;
            _resultCategoryConsume = resultCategoryConsume;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _resultProductConsume.GetListAsync("products/productlistwithcategory");

            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.categories = await GetCategories();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            var result = await _createProductConsume.PostAsync("products/createproduct", dto);
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
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _deleteProductConsume.DeleteAsync("products/deleteproduct", id);
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
        public async Task<ActionResult> UpdateProduct(int id)
        {
            var values = await _getProductByIdConsume.GetByIdAsync("products/getproduct", id);
            ViewBag.categories = await GetCategories();
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateProduct(UpdateProductDto dto)
        {
            var result = await _updateProductConsume.PutAsync("products/updateproduct", dto);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.categories = await GetCategories();
                TempData["ErrorMessage"] = "Güncelleme işlemi sırasında bir hata oluştu";
                return RedirectToAction("Index");
            }
        }

        private async Task<List<ResultCategoryDto>> GetCategories() => await _resultCategoryConsume.GetListAsync("categories/categorylist");
    }
}
