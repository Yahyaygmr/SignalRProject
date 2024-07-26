using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
