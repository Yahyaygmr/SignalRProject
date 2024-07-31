using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.SocialMediaDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly Consume<ResultSocialMediaDto> _resultSocialMediaConsume;
        private readonly Consume<CreateSocialMediaDto> _createSocialMediaConsume;
        private readonly Consume<object> _deleteSocialMediaConsume;
        private readonly Consume<GetSocialMediaByIdDto> _getSocialMediaByIdConsume;
        private readonly Consume<UpdateSocialMediaDto> _updateSocialMediaConsume;

        public SocialMediaController(Consume<ResultSocialMediaDto> resultSocialMediaConsume, Consume<CreateSocialMediaDto> createSocialMediaConsume, Consume<object> deleteSocialMediaConsume, Consume<GetSocialMediaByIdDto> getSocialMediaByIdConsume, Consume<UpdateSocialMediaDto> updateSocialMediaConsume)
        {
            _resultSocialMediaConsume = resultSocialMediaConsume;
            _createSocialMediaConsume = createSocialMediaConsume;
            _deleteSocialMediaConsume = deleteSocialMediaConsume;
            _getSocialMediaByIdConsume = getSocialMediaByIdConsume;
            _updateSocialMediaConsume = updateSocialMediaConsume;
        }

        public async Task<IActionResult> Index()
        {
            var socialMedias = await _resultSocialMediaConsume.GetListAsync("socialMedias/socialMedialist");

            return View(socialMedias);
        }
        [HttpGet]
        public async Task<IActionResult> CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto dto)
        {
            var result = await _createSocialMediaConsume.PostAsync("socialMedias/createsocialMedia", dto);
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
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var result = await _deleteSocialMediaConsume.DeleteAsync("socialMedias/delete", id);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Silme işlemi sırasında bir hata oluştu";
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public async Task<ActionResult> UpdateSocialMedia(int id)
        {
            var values = await _getSocialMediaByIdConsume.GetByIdAsync("socialMedias/getsocialMedia", id);
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateSocialMedia(UpdateSocialMediaDto dto)
        {
            var result = await _updateSocialMediaConsume.PutAsync("socialMedias/updatesocialMedia", dto);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Güncelleme işlemi sırasında bir hata oluştu";
                return RedirectToAction("Index");
            }
        }
    }
}
