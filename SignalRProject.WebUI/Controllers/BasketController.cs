using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.BasketDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly Consume<ResultBasketDto> _resultBasketConsume;

        public BasketController(Consume<ResultBasketDto> resultBasketConsume)
        {
            _resultBasketConsume = resultBasketConsume;
        }

        public async Task<IActionResult> Index(int id=4)
        {
            var values = await _resultBasketConsume.GetListByIdAsync("baskets/GetBasketByMenuTableId", id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket()
        {
            return View();
        }
    }
}
