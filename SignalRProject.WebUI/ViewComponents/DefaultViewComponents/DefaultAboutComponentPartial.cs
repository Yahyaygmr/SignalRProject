using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.AboutDtos;

namespace SignalRProject.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultAboutComponentPartial : ViewComponent
    {
        private readonly Consume<GetAboutByIdDto> _getAboutConsume;

        public DefaultAboutComponentPartial(Consume<GetAboutByIdDto> getAboutConsume)
        {
            _getAboutConsume = getAboutConsume;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value =await _getAboutConsume.GetByIdAsync("abouts/getabout", 1);
            return View(value);
        }
    }
}
