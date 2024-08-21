using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.WebUI.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
