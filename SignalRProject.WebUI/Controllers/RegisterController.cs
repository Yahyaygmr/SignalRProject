using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.EntityLayer.Entities;
using SignalRProject.WebUI.Dtos.IdentityDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto dto)
        {
            var appUser = new AppUser()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Mail,
                UserName = dto.Username
            };
            var result = await _userManager.CreateAsync(appUser, dto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
