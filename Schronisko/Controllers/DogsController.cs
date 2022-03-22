using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schronisko.Models;
using Schronisko.Service;

namespace Schronisko.Controllers
{
    [Authorize]
    public class DogsController : Controller
    {
        private readonly IDogService _service;

        public DogsController(IDogService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var dogs = await _service.GetAll();
            return View(dogs);
        }
        
        public async Task<IActionResult> Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(DogModel dogModel)
        {
            if (!ModelState.IsValid) return View(dogModel);
            await _service.Create(dogModel);
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Update(int id)
        {
            var dog = await _service.GetById(id);
            if (dog == null) return View("Error");
            var dogEntity = new DogModel()
            {
                Id = dog.Id,
                Name=dog.Name,
                Photo = dog.Photo,
                Phone = dog.Phone,
                Age=dog.Age,
            };
            return View(dogEntity);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(int id, DogModel dogModel)
        {
            if (id != dogModel.Id) return View("Error");
            if (!ModelState.IsValid) return View(dogModel);
            await _service.Update(dogModel);
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var dog = await _service.GetById(id);
            if (dog == null) return View("Error");
            await _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}