using Microsoft.AspNetCore.Mvc;

namespace CroKnitters.Controllers
{
    public class PatternController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateNewPattern()
        {
            return View("CreatePattern");
        }

        [HttpPost]
        public IActionResult CreatePattern()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditPattern()
        {
            return View("CreatePattern");
        }

        //[HttpPost]
        //public IActionResult EditPattern()
        //{
        //    return View("CreatePattern");
        //}
    }
}
