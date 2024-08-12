using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.DiscountDtos;

namespace SignalRProject.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultOfferComponentPartial : ViewComponent
    {
        private readonly Consume<ResultDiscountDto> _resultDiscountConsume;

        public DefaultOfferComponentPartial(Consume<ResultDiscountDto> resultDiscountConsume)
        {
            _resultDiscountConsume = resultDiscountConsume;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _resultDiscountConsume.GetListAsync("discounts/discountlist");
            return View(values);
        }
    }
}
