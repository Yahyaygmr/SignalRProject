using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UILayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
