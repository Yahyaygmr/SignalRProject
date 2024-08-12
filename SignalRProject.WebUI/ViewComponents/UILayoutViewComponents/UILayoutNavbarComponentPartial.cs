using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UILayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
