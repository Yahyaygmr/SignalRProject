using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.DtoLayer.TestimonialDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : BasesController
    {
        [HttpGet("TestimonialList")]
        public IActionResult TestimonialList()
        {
            var values = _serviceManager.testimonialService.GetAll();
            return Ok(values);
        }
        [HttpPost("CreateTestimonial")]
        public IActionResult CreateTestimonial(CreateTestimonialDto dto)
        {
            var result = _mapper.Map<Testimonial>(dto);

            _serviceManager.testimonialService.Add(result);

            return Ok("Referans eklendi.");
        }
        [HttpDelete("DeleteTestimonial/{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            _serviceManager.testimonialService.Delete(id);
            return Ok("Referans silindi.");
        }
        [HttpPut("UpdateTestimonial")]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto dto)
        {
            var result = _mapper.Map<Testimonial>(dto);
            _serviceManager.testimonialService.Update(result);
            return Ok("Referans güncellendi");
        }
        [HttpGet("GetTestimonial/{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _serviceManager.testimonialService.GetById(id);
            return Ok(value);
        }

        [HttpGet("TestimonialCount")]
        public IActionResult TestimonialCount()
        {
            var values = _serviceManager.testimonialService.TestimonialCount();
            return Ok(values);
        }
    }
}
