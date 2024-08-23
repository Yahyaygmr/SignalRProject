using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultMessageComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
