using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.EntityLayer.Entities;
using SignalRProject.WebUI.Dtos.IdentityDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto editUser = new()
            {
                Name = value.Name,
                Surname = value.Surname,
                Mail = value.Email,
                UserName = value.UserName
            };
            return View(editUser);
        }
        [HttpPost]
        public  async Task<IActionResult> Index(UserEditDto dto)
        {
            if(dto.Password == dto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                user.Name = dto.Name;
                user.Surname = dto.Surname;
                user.UserName = dto.UserName;
                user.Email = dto.Mail;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, dto.Password);

               await _userManager.UpdateAsync(user);
                return RedirectToAction("Index","Category");
            }
            return View();
        }
    }
}
