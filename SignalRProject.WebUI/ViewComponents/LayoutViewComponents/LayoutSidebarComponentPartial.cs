using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.WebUI.ViewComponents.LayoutViewComponents
{
    public class LayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}

