using Microsoft.AspNetCore.Mvc;

namespace CroKnitters.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateNewProject() { 
            return View("CreateProject");
        }

        [HttpPost]
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditProject()
        {
            return View("CreateProject");
        }

        //[HttpPost]
        //public IActionResult EditProject()
        //{
        //    return View("CreateProject");
        //}
    }
}
