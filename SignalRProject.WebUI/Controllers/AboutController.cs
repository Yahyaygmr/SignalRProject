using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.AboutDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly Consume<CreateAboutDto> _createAboutConsume;
        private readonly Consume<GetAboutByIdDto> _getAboutByIdConsume;
        private readonly Consume<UpdateAboutDto> _updateAboutConsume;

        public AboutController(Consume<CreateAboutDto> createAboutConsume, Consume<GetAboutByIdDto> getAboutByIdConsume, Consume<UpdateAboutDto> updateAboutConsume)
        {
            _createAboutConsume = createAboutConsume;
            _getAboutByIdConsume = getAboutByIdConsume;
            _updateAboutConsume = updateAboutConsume;
        }

        [HttpGet]
        public async Task<IActionResult> CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto dto)
        {
            var result = await _createAboutConsume.PostAsync("abouts/createabout", dto);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Kaydetme işlemi sırasında bir hata oluştu";
                return View(dto);
            }
        }
        [HttpGet]
        public async Task<ActionResult> UpdateAbout(int id = 1)
        {
            var values = await _getAboutByIdConsume.GetByIdAsync("abouts/getabout", id);
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateAbout(UpdateAboutDto dto)
        {
            var result = await _updateAboutConsume.PutAsync("abouts/updateabout", dto);
            if (result > 0)
            {
                TempData["Message"] = "Güncelleme işlemi başarılı.";
                return RedirectToAction("UpdateAbout");
            }
            else
            {
                TempData["Message"] = "Güncelleme işlemi sırasında bir hata oluştu";
                return RedirectToAction("UpdateAbout");
            }
        }
    }
}
