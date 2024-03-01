using Microsoft.AspNetCore.Mvc;

namespace CroKnitters.Controllers
{
    public class FriendController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult FindFriend()
        {
            return View("AddFriend");
        }

        [HttpPost]
        public ActionResult AddFriend()
        {
            //When 
            return View("AddFriend");
        }

        [HttpPost]
        public ActionResult DeleteFriend()
        {
            //When 
            return RedirectToAction("Index");
        }

    }
}
