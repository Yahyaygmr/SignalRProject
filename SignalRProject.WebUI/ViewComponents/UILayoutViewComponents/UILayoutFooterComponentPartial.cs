using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UILayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
