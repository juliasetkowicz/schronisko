using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schronisko.Models;
using Schronisko.Service;

namespace Schronisko.Controllers
{
    [Authorize]
    public class CatsController : Controller
    {
        private readonly ICatService _service;

        public CatsController(ICatService service)
        {
            _service = service;
        }



        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var cats = await _service.GetAll();
            return View(cats);
        }
        
        public async Task<IActionResult> Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CatModel catModel)
        {
            if (!ModelState.IsValid) return View(catModel);
            await _service.Create(catModel);
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Update(int id)
        {
            var cat = await _service.GetById(id);
            if (cat == null) return View("Error");
            var catEntity = new CatModel()
            {
                Id = cat.Id,
                Name=cat.Name,
                Photo = cat.Photo,
                Phone = cat.Phone,
                Age=cat.Age,
            };
            return View(catEntity);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, CatModel catModel)
        {
            if (id != catModel.Id) return View("Error");
            if (!ModelState.IsValid) return View(catModel);
            await _service.Update(catModel);
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _service.GetById(id);
            if (cat == null) return View("Error");
            await _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
