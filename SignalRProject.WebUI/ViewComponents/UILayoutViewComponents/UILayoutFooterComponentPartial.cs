using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.ContactDtos;

namespace SignalRProject.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UILayoutFooterComponentPartial : ViewComponent
    {
        private readonly Consume<GetContactByIdDto> _getContactByIdConsume;

        public UILayoutFooterComponentPartial(Consume<GetContactByIdDto> getContactByIdConsume)
        {
            _getContactByIdConsume = getContactByIdConsume;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _getContactByIdConsume.GetByIdAsync("contacts/getcontact", 1);
            return View(value);
        }
    }
}
