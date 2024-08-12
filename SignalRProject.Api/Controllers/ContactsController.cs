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
        [HttpGet("ContactList")]
        public IActionResult ContactList()
        {
            var values = _serviceManager.contactService.GetAll();
            return Ok(values);
        }
        [HttpPost("CreateContact")]
        public IActionResult CreateContact(CreateContactDto dto)
        {
            var result = _mapper.Map<Contact>(dto);

            _serviceManager.contactService.Add(result);

            return Ok("İletişim bilgisi eklendi.");
        }
        [HttpDelete("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            _serviceManager.contactService.Delete(id);
            return Ok("İletişim bilgisi silindi.");
        }
        [HttpPut("UpdateContact")]
        public IActionResult UpdateContact(UpdateContactDto dto)
        {
            var result = _mapper.Map<Contact>(dto);
            _serviceManager.contactService.Update(result);
            return Ok("İletişim bilgisi güncellendi");
        }
        [HttpGet("GetContact/{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _serviceManager.contactService.GetById(id);
            return Ok(value);
        }

        [HttpGet("ContactCount")]
        public IActionResult ContactCount()
        {
            var values = _serviceManager.contactService.ContactCount();
            return Ok(values);
        }
    }
}
