using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.MenuTableDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class MenuTableController : Controller
    {
        private readonly Consume<ResultMenuTableDto> _resultMenuTableConsume;
        private readonly Consume<CreateMenuTableDto> _createMenuTableConsume;
        private readonly Consume<object> _deleteMenuTableConsume;
        private readonly Consume<GetMenuTableByIdDto> _getMenuTableByIdConsume;
        private readonly Consume<UpdateMenuTableDto> _updateMenuTableConsume;

        public MenuTableController(Consume<ResultMenuTableDto> resultMenuTableConsume, Consume<CreateMenuTableDto> createMenuTableConsume, Consume<object> deleteMenuTableConsume, Consume<GetMenuTableByIdDto> getMenuTableByIdConsume, Consume<UpdateMenuTableDto> updateMenuTableConsume)
        {
            _resultMenuTableConsume = resultMenuTableConsume;
            _createMenuTableConsume = createMenuTableConsume;
            _deleteMenuTableConsume = deleteMenuTableConsume;
            _getMenuTableByIdConsume = getMenuTableByIdConsume;
            _updateMenuTableConsume = updateMenuTableConsume;
        }

        public async Task<IActionResult> Index()
        {
            var menutables = await _resultMenuTableConsume.GetListAsync("menutables/menuTablelist");
            return View(menutables);
        }
        [HttpGet]
        public async Task<IActionResult> CreateMenuTable()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto dto)
        {
            dto.Status = false;
            var result = await _createMenuTableConsume.PostAsync("menutables/createmenuTable", dto);
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
        public async Task<IActionResult> DeleteMenuTable(int id)
        {
           var result = await _deleteMenuTableConsume.DeleteAsync("menutables/deletemenutable", id);
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
        public async Task<ActionResult> UpdateMenuTable(int id)
        {
            var values = await _getMenuTableByIdConsume.GetByIdAsync("menutables/getmenuTable", id);
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateMenuTable(UpdateMenuTableDto dto)
        {
            var result = await _updateMenuTableConsume.PutAsync("menutables/updatemenuTable", dto);
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
        public async Task<IActionResult> MenuTableListByStatus()
        {
            var menutables = await _resultMenuTableConsume.GetListAsync("menutables/menuTablelist");
            return View(menutables);
        }

    }
}
