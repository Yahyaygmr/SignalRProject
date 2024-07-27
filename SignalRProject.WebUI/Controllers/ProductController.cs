using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.PoductDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly Consume<ResultProductDto> _resultProductConsume;
        private readonly Consume<CreateProductDto> _createProductConsume;
        private readonly Consume<object> _deleteProductConsume;
        private readonly Consume<GetProductByIdDto> _getProductByIdConsume;
        private readonly Consume<UpdateProductDto> _updateProductConsume;

        public ProductController(Consume<ResultProductDto> resultProductConsume, Consume<CreateProductDto> createProductConsume, Consume<object> deleteProductConsume, Consume<GetProductByIdDto> getProductByIdConsume, Consume<UpdateProductDto> updateProductConsume)
        {
            _resultProductConsume = resultProductConsume;
            _createProductConsume = createProductConsume;
            _deleteProductConsume = deleteProductConsume;
            _getProductByIdConsume = getProductByIdConsume;
            _updateProductConsume = updateProductConsume;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _resultProductConsume.GetListAsync("products/productlist");

            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
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
            var result = await _deleteProductConsume.DeleteAsync("products/delete", id);
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
                TempData["ErrorMessage"] = "Güncelleme işlemi sırasında bir hata oluştu";
                return RedirectToAction("Index");
            }
        }
    }
}
