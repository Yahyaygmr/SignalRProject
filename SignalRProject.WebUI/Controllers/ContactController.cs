using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.ContactDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly Consume<ResultContactDto> _resultContactConsume;
        private readonly Consume<CreateContactDto> _createContactConsume;
        private readonly Consume<object> _deleteContactConsume;
        private readonly Consume<GetContactByIdDto> _getContactByIdConsume;
        private readonly Consume<UpdateContactDto> _updateContactConsume;

        public ContactController(Consume<ResultContactDto> resultContactConsume, Consume<CreateContactDto> createContactConsume, Consume<object> deleteContactConsume, Consume<GetContactByIdDto> getContactByIdConsume, Consume<UpdateContactDto> updateContactConsume)
        {
            _resultContactConsume = resultContactConsume;
            _createContactConsume = createContactConsume;
            _deleteContactConsume = deleteContactConsume;
            _getContactByIdConsume = getContactByIdConsume;
            _updateContactConsume = updateContactConsume;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _resultContactConsume.GetListAsync("contacts/contactlist");

            return View(contacts);
        }
        [HttpGet]
        public async Task<IActionResult> CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto dto)
        {
            var result = await _createContactConsume.PostAsync("contacts/createcontact", dto);
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
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _deleteContactConsume.DeleteAsync("contacts/delete", id);
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
        public async Task<ActionResult> UpdateContact(int id)
        {
            var values = await _getContactByIdConsume.GetByIdAsync("contacts/getcontact", id);
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateContact(UpdateContactDto dto)
        {
            var result = await _updateContactConsume.PutAsync("contacts/updatecontact", dto);
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
