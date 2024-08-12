using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.PoductDtos;
using System.Drawing.Text;

namespace SignalRProject.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultOurMenuComponentPartial : ViewComponent
    {
        private readonly Consume<ResultProductDto> _resultProductConsume;

        public DefaultOurMenuComponentPartial(Consume<ResultProductDto> resultProductConsume)
        {
            _resultProductConsume = resultProductConsume;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _resultProductConsume.GetListAsync("products/productlist");
            return View(values);
        }
    }
}
