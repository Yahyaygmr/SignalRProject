using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.DiscountDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly Consume<ResultDiscountDto> _resultDiscountConsume;
        private readonly Consume<CreateDiscountDto> _createDiscountConsume;
        private readonly Consume<object> _deleteDiscountConsume;
        private readonly Consume<GetDiscountByIdDto> _getDiscountByIdConsume;
        private readonly Consume<UpdateDiscountDto> _updateDiscountConsume;

        public DiscountController(Consume<ResultDiscountDto> resultDiscountConsume, Consume<CreateDiscountDto> createDiscountConsume, Consume<object> deleteDiscountConsume, Consume<GetDiscountByIdDto> getDiscountByIdConsume, Consume<UpdateDiscountDto> updateDiscountConsume)
        {
            _resultDiscountConsume = resultDiscountConsume;
            _createDiscountConsume = createDiscountConsume;
            _deleteDiscountConsume = deleteDiscountConsume;
            _getDiscountByIdConsume = getDiscountByIdConsume;
            _updateDiscountConsume = updateDiscountConsume;
        }

        public async Task<IActionResult> Index()
        {
            var discounts = await _resultDiscountConsume.GetListAsync("discounts/discountlist");

            return View(discounts);
        }
        [HttpGet]
        public async Task<IActionResult> CreateDiscount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto dto)
        {
            var result = await _createDiscountConsume.PostAsync("discounts/creatediscount", dto);
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
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var result = await _deleteDiscountConsume.DeleteAsync("discounts/delete", id);
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
        public async Task<ActionResult> UpdateDiscount(int id)
        {
            var values = await _getDiscountByIdConsume.GetByIdAsync("discounts/getdiscount", id);
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateDiscount(UpdateDiscountDto dto)
        {
            var result = await _updateDiscountConsume.PutAsync("discounts/updatediscount", dto);
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
