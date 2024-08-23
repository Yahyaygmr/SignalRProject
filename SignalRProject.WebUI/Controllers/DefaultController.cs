using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.MessageDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Consume<CreateMessageDto> _createMessageConsume;

        public DefaultController(Consume<CreateMessageDto> createMessageConsume)
        {
            _createMessageConsume = createMessageConsume;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto dto)
        {
            var result = await _createMessageConsume.PostAsync("messages/createmessage", dto);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
