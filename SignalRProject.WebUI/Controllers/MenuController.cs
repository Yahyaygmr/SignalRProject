using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.BasketDtos;
using SignalRProject.WebUI.Dtos.PoductDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly Consume<ResultProductDto> _resultProducConsume;
        private readonly Consume<CreateBasketDto> _createBasketConsume;

        public MenuController(Consume<ResultProductDto> resultProducConsume, Consume<CreateBasketDto> createBasketConsume)
        {
            _resultProducConsume = resultProducConsume;
            _createBasketConsume = createBasketConsume;
        }

        public  async Task<IActionResult> Index()
        {
            var values = await _resultProducConsume.GetListAsync("products/productlist");
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id)
        {
            CreateBasketDto dto = new CreateBasketDto();
            dto.ProductId = id;

            var result = await _createBasketConsume.PostAsync("baskets/createbasket", dto);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }

            return View(dto);
        }
    }
}
