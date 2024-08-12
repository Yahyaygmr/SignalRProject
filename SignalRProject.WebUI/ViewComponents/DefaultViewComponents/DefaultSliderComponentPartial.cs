using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultSliderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
