using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.DtoLayer.DiscountDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : BasesController
    {
        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _serviceManager.discountService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto dto)
        {
            var result = _mapper.Map<Discount>(dto);

            _serviceManager.discountService.Add(result);

            return Ok("İndidrim bilgisi eklendi.");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _serviceManager.discountService.Delete(id);
            return Ok("İndidrim bilgisi silindi.");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto dto)
        {
            var result = _mapper.Map<Discount>(dto);
            _serviceManager.discountService.Update(result);
            return Ok("İndidrim bilgisi güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _serviceManager.discountService.GetById(id);
            return Ok(value);
        }
    }
}
