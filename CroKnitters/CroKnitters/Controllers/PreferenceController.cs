using Microsoft.AspNetCore.Mvc;

namespace CroKnitters.Controllers
{
    public class PreferenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditPreference()
        {
            return View();
        }
    }
}
