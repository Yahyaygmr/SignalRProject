using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.DtoLayer.MenuTableDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : BasesController
    {
        [HttpGet("[action]")]
        public IActionResult MenuTableList()
        {
            var values = _serviceManager.menuTableService.GetAll();
            var result = _mapper.Map<List<ResultMenuTableDto>>(values);
            return Ok(result);
        }
        [HttpPost("[action]")]
        public IActionResult CreateMenuTable(CreateMenuTableDto dto)
        {
            var result = _mapper.Map<MenuTable>(dto);

            _serviceManager.menuTableService.Add(result);

            return Ok("Kategori eklendi.");
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            _serviceManager.menuTableService.Delete(id);
            return Ok("Kategori silindi.");
        }
        [HttpPut("[action]")]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto dto)
        {
            var result = _mapper.Map<MenuTable>(dto);
            _serviceManager.menuTableService.Update(result);
            return Ok("Kategori güncellendi");
        }
        [HttpGet("[action]/{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _serviceManager.menuTableService.GetById(id);
            var result = _mapper.Map<GetMenuTableByIdDto>(value);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult MenuTableCount()
        {
            var values = _serviceManager.menuTableService.MenuTableCount();
            return Ok(values);
        }
    }
}
