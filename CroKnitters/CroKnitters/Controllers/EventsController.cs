using Microsoft.AspNetCore.Mvc;

namespace CroKnitters.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
