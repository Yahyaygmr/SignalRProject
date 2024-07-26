using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.WebUI.ViewComponents.LayoutViewComponents
{
    public class LayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
