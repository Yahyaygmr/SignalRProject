using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.TestimonialDtos;


namespace SignalRProject.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultTestimonialComponentPartial : ViewComponent
    {
        private readonly Consume<ResultTestimonialDto> _resultTestimonialConsume;

        public DefaultTestimonialComponentPartial(Consume<ResultTestimonialDto> resultTestimonialConsume)
        {
            _resultTestimonialConsume = resultTestimonialConsume;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _resultTestimonialConsume.GetListAsync("testimonials/testimoniallist");
            return View(values);
        }
    }
}
