using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
