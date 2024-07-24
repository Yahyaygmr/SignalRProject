using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.DtoLayer.ContactDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : BasesController
    {
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _serviceManager.contactService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto dto)
        {
            var result = _mapper.Map<Contact>(dto);

            _serviceManager.contactService.Add(result);

            return Ok("İletişim bilgisi eklendi.");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _serviceManager.contactService.Delete(id);
            return Ok("İletişim bilgisi silindi.");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto dto)
        {
            var result = _mapper.Map<Contact>(dto);
            _serviceManager.contactService.Update(result);
            return Ok("İletişim bilgisi güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _serviceManager.contactService.GetById(id);
            return Ok(value);
        }
    }
}
