using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.PoductDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly Consume<ResultProductDto> _resultProducConsume;

        public MenuController(Consume<ResultProductDto> resultProducConsume)
        {
            _resultProducConsume = resultProducConsume;
        }

        public  async Task<IActionResult> Index()
        {
            var values = await _resultProducConsume.GetListAsync("products/productlist");
            return View(values);
        }
    }
}
