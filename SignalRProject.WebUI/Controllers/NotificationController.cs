using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.NotificationDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Consume<ResultNotificationDto> _resultNotificationConsume;
        private readonly Consume<CreateNotificationDto> _createNotificationConsume;
        private readonly Consume<object> _deleteNotificationConsume;
        private readonly Consume<GetNotificationByIdDto> _getNotificationByIdConsume;
        private readonly Consume<UpdateNotificationDto> _updateNotificationConsume;

        public NotificationController(Consume<ResultNotificationDto> resultNotificationConsume, Consume<CreateNotificationDto> createNotificationConsume, Consume<object> deleteNotificationConsume, Consume<GetNotificationByIdDto> getNotificationByIdConsume, Consume<UpdateNotificationDto> updateNotificationConsume, IHttpClientFactory httpClientFactory)
        {
            _resultNotificationConsume = resultNotificationConsume;
            _createNotificationConsume = createNotificationConsume;
            _deleteNotificationConsume = deleteNotificationConsume;
            _getNotificationByIdConsume = getNotificationByIdConsume;
            _updateNotificationConsume = updateNotificationConsume;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var notifications = await _resultNotificationConsume.GetListAsync("notifications/notificationlist");

            return View(notifications);
        }
        [HttpGet]
        public async Task<IActionResult> CreateNotification()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto dto)
        {
            var result = await _createNotificationConsume.PostAsync("notifications/createnotification", dto);
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
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var result = await _deleteNotificationConsume.DeleteAsync("notifications/deletenotification", id);
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
        public async Task<ActionResult> UpdateNotification(int id)
        {
            var values = await _getNotificationByIdConsume.GetByIdAsync("notifications/getnotification", id);
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateNotification(UpdateNotificationDto dto)
        {
            var result = await _updateNotificationConsume.PutAsync("notifications/updatenotification", dto);
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
        [HttpGet]
        public async Task<ActionResult> UpdateNotificationStatusFalse(int id)
        {
            var responseMessage = await _httpClientFactory.CreateClient().GetAsync($"https://localhost:44343/api/Notifications/NotificationStatusChangeToFalse/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            //await _getNotificationByIdConsume.GetByIdAsync("notifications/NotificationStatusChangeToTrue", id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> UpdateNotificationStatusTrue(int id)
        {
            var responseMessage = await _httpClientFactory.CreateClient().GetAsync($"https://localhost:44343/api/Notifications/NotificationStatusChangeToTrue/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            await _getNotificationByIdConsume.GetByIdAsync("notifications/NotificationStatusChangeToTrue", id);
            return RedirectToAction("Index");
        }
    }
}
