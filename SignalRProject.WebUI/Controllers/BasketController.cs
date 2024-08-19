using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using SignalRProject.WebUI.Dtos.BasketDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly Consume<ResultBasketDto> _resultBasketConsume;
        private readonly Consume<object> _deleteBasketConsume;

        public BasketController(Consume<ResultBasketDto> resultBasketConsume, Consume<object> deleteBasketConsume)
        {
            _resultBasketConsume = resultBasketConsume;
            _deleteBasketConsume = deleteBasketConsume;
        }

        public async Task<IActionResult> Index(int id = 4)
        {
            var values = await _resultBasketConsume.GetListByIdAsync("baskets/GetBasketByMenuTableId", id);
            return View(values);
        }
        public async Task<IActionResult> DeleteFromBasket(int id)
        {
            var result = await _deleteBasketConsume.DeleteAsync("baskets/deletebasket", id);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
