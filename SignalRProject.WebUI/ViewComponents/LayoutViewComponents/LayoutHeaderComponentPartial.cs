using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.WebUI.ViewComponents.LayoutViewComponents
{
    public class LayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
