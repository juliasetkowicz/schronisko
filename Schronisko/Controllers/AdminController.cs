using Microsoft.AspNetCore.Mvc;

namespace Schronisko.Controllers
{
    public class AdminController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}