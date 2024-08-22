using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.DtoLayer.BookingDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : BasesController
    {
        [HttpGet("[action]")]
        public IActionResult BookingList()
        {
            var values = _serviceManager.bookingService.GetAll();
            return Ok(values);
        }
        [HttpPost("[action]")]
        public IActionResult CreateBooking(CreateBookingDto dto)
        {
            var result = _mapper.Map<Booking>(dto);
            result.Description = "Rezervasyon Alındı";
            _serviceManager.bookingService.Add(result);

            return Ok("Rezervasyon işlemi eklendi.");
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteBooking(int id)
        {
            _serviceManager.bookingService.Delete(id);
            return Ok("Rezervasyon işlemi silindi.");
        }
        [HttpPut("[action]")]
        public IActionResult UpdateBooking(UpdateBookingDto dto)
        {
            var result = _mapper.Map<Booking>(dto);
            _serviceManager.bookingService.Update(result);
            return Ok("Rezervasyon işlemi güncellendi");
        }
        [HttpGet("[action]/{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _serviceManager.bookingService.GetById(id);
            var result = _mapper.Map<GetBookingDto>(value);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult BookingCount()
        {
            var values = _serviceManager.bookingService.BookingCount();
            return Ok(values);
        }
        [HttpGet("[action]/{id}")]
        public IActionResult SetBookingStatusApproved(int id)
        {
            _serviceManager.bookingService.BookingSetStatusApproved(id);
            return Ok("Rezervasyon Durumu Onaylandı Olarak Güncellendi");
        }
        [HttpGet("[action]/{id}")]
        public IActionResult SetBookingStatusCancelled(int id)
        {
            _serviceManager.bookingService.BookingSetStatusCancelled(id);
            return Ok("Rezervasyon Durumu İptal Edildi Olarak Güncellendi");
        }
    }
}
