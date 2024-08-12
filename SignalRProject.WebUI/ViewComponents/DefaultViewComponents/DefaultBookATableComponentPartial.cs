using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultBookATableComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
