using DynamicConsume;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.WebUI.Dtos.FeatureDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class FeatureController : Controller
    {
        private readonly Consume<ResultFeatureDto> _resultFeatureConsume;
        private readonly Consume<CreateFeatureDto> _createFeatureConsume;
        private readonly Consume<object> _deleteFeatureConsume;
        private readonly Consume<GetFeatureByIdDto> _getFeatureByIdConsume;
        private readonly Consume<UpdateFeatureDto> _updateFeatureConsume;

        public FeatureController(Consume<ResultFeatureDto> resultFeatureConsume, Consume<CreateFeatureDto> createFeatureConsume, Consume<object> deleteFeatureConsume, Consume<GetFeatureByIdDto> getFeatureByIdConsume, Consume<UpdateFeatureDto> updateFeatureConsume)
        {
            _resultFeatureConsume = resultFeatureConsume;
            _createFeatureConsume = createFeatureConsume;
            _deleteFeatureConsume = deleteFeatureConsume;
            _getFeatureByIdConsume = getFeatureByIdConsume;
            _updateFeatureConsume = updateFeatureConsume;
        }

        public async Task<IActionResult> Index()
        {
            var features = await _resultFeatureConsume.GetListAsync("features/featurelist");

            return View(features);
        }
        [HttpGet]
        public async Task<IActionResult> CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto dto)
        {
            var result = await _createFeatureConsume.PostAsync("features/createfeature", dto);
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
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var result = await _deleteFeatureConsume.DeleteAsync("features/delete", id);
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
        public async Task<ActionResult> UpdateFeature(int id)
        {
            var values = await _getFeatureByIdConsume.GetByIdAsync("features/getfeature", id);
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateFeature(UpdateFeatureDto dto)
        {
            var result = await _updateFeatureConsume.PutAsync("features/updatefeature", dto);
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
