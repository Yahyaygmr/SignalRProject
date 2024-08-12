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
        [HttpGet("BookingList")]
        public IActionResult BookingList()
        {
            var values = _serviceManager.bookingService.GetAll();
            return Ok(values);
        }
        [HttpPost("CreateBooking")]
        public IActionResult CreateBooking(CreateBookingDto dto)
        {
            var result = _mapper.Map<Booking>(dto);

            _serviceManager.bookingService.Add(result);

            return Ok("Rezervasyon işlemi eklendi.");
        }
        [HttpDelete("DeleteBooking/{id}")]
        public IActionResult DeleteBooking(int id)
        {
            _serviceManager.bookingService.Delete(id);
            return Ok("Rezervasyon işlemi silindi.");
        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(UpdateBookingDto dto)
        {
            var result = _mapper.Map<Booking>(dto);
            _serviceManager.bookingService.Update(result);
            return Ok("Rezervasyon işlemi güncellendi");
        }
        [HttpGet("GetBooking/{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _serviceManager.bookingService.GetById(id);
            return Ok(value);
        }

        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var values = _serviceManager.bookingService.BookingCount();
            return Ok(values);
        }
    }
}
