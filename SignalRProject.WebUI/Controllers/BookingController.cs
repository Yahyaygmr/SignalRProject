using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.BookingDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly Consume<ResultBookingDto> _resultBookingConsume;
        private readonly Consume<CreateBookingDto> _createBookingConsume;
        private readonly Consume<object> _deleteBookingConsume;
        private readonly Consume<GetBookingByIdDto> _getBookingByIdConsume;
        private readonly Consume<UpdateBookingDto> _updateBookingConsume;
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(Consume<ResultBookingDto> resultBookingConsume, Consume<CreateBookingDto> createBookingConsume, Consume<object> deleteBookingConsume, Consume<GetBookingByIdDto> getBookingByIdConsume, Consume<UpdateBookingDto> updateBookingConsume, IHttpClientFactory httpClientFactory)
        {
            _resultBookingConsume = resultBookingConsume;
            _createBookingConsume = createBookingConsume;
            _deleteBookingConsume = deleteBookingConsume;
            _getBookingByIdConsume = getBookingByIdConsume;
            _updateBookingConsume = updateBookingConsume;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await _resultBookingConsume.GetListAsync("bookings/bookinglist");

            return View(bookings);
        }
        [HttpGet]
        public async Task<IActionResult> CreateBooking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto dto)
        {
            var result = await _createBookingConsume.PostAsync("bookings/createbooking", dto);
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
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _deleteBookingConsume.DeleteAsync("bookings/deletebooking", id);
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
        public async Task<ActionResult> UpdateBooking(int id)
        {
            var values = await _getBookingByIdConsume.GetByIdAsync("bookings/getbooking", id);
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateBooking(UpdateBookingDto dto)
        {
            var result = await _updateBookingConsume.PutAsync("bookings/updatebooking", dto);
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
        public async Task<IActionResult> SetBookingStatusApproved(int id)
        {
            var responseMessage = await _httpClientFactory.CreateClient().GetAsync($"https://localhost:44343/api/Bookings/SetBookingStatusApproved/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> SetBookingStatusCancelled(int id)
        {
            var responseMessage = await _httpClientFactory.CreateClient().GetAsync($"https://localhost:44343/api/Bookings/SetBookingStatusCancelled/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
