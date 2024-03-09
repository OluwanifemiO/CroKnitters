using CroKnitters.Entities;
using CroKnitters.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CroKnitters.Controllers
{
    public class ProfileController : Controller
    { 
        public ProfileController(CrochetAppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            string userId = Request.Cookies["userId"];

            if (!string.IsNullOrEmpty(userId))
            {
                int userIdValue;
                if (int.TryParse(userId, out userIdValue))
                {
                    User user = _db.Users.FirstOrDefault(m => m.UserId == userIdValue);

                    if (user != null)
                    {
                        return View("Index", user);
                    }
                }
            }
            // If any of the cookies are missing, redirect to login

            return RedirectToAction("Login", "Account");
        }

        public ActionResult EditProfile()
        {
            int userId = int.Parse(Request.Cookies["userId"]!);
            User user = _db.Users.Find(userId)!;

            return View(user);
        }

        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            _db.Users.Update(user);
            _db.SaveChanges();

            return RedirectToAction("Index", "Profile");
        }

        private CrochetAppDbContext _db;

      
    }
}
