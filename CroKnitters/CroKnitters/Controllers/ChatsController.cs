using Microsoft.AspNetCore.Mvc;

namespace CroKnitters.Controllers
{
    public class ChatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
