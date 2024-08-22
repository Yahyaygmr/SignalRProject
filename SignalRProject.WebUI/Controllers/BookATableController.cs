using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.BookingDtos;

namespace SignalRProject.WebUI.Controllers
{
    
    public class BookATableController : Controller
    {
        private readonly Consume<CreateBookingDto> _createBookingConsume;

        public BookATableController(Consume<CreateBookingDto> createBookingConsume)
        {
            _createBookingConsume = createBookingConsume;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto dto)
        {
            dto.Description = "";
            var result = await _createBookingConsume.PostAsync("bookings/createbooking", dto);
            if(result>0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
