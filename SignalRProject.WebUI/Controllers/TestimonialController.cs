using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.TestimonialDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly Consume<ResultTestimonialDto> _resultTestimonialConsume;
        private readonly Consume<CreateTestimonialDto> _createTestimonialConsume;
        private readonly Consume<object> _deleteTestimonialConsume;
        private readonly Consume<GetTestimonialByIdDto> _getTestimonialByIdConsume;
        private readonly Consume<UpdateTestimonialDto> _updateTestimonialConsume;

        public TestimonialController(Consume<ResultTestimonialDto> resultTestimonialConsume, Consume<CreateTestimonialDto> createTestimonialConsume, Consume<object> deleteTestimonialConsume, Consume<GetTestimonialByIdDto> getTestimonialByIdConsume, Consume<UpdateTestimonialDto> updateTestimonialConsume)
        {
            _resultTestimonialConsume = resultTestimonialConsume;
            _createTestimonialConsume = createTestimonialConsume;
            _deleteTestimonialConsume = deleteTestimonialConsume;
            _getTestimonialByIdConsume = getTestimonialByIdConsume;
            _updateTestimonialConsume = updateTestimonialConsume;
        }

        public async Task<IActionResult> Index()
        {
            var testimonials = await _resultTestimonialConsume.GetListAsync("testimonials/testimoniallist");

            return View(testimonials);
        }
        [HttpGet]
        public async Task<IActionResult> CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto dto)
        {
            var result = await _createTestimonialConsume.PostAsync("testimonials/createtestimonial", dto);
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
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var result = await _deleteTestimonialConsume.DeleteAsync("testimonials/delete", id);
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
        public async Task<ActionResult> UpdateTestimonial(int id)
        {
            var values = await _getTestimonialByIdConsume.GetByIdAsync("testimonials/gettestimonial", id);
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateTestimonial(UpdateTestimonialDto dto)
        {
            var result = await _updateTestimonialConsume.PutAsync("testimonials/updatetestimonial", dto);
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
