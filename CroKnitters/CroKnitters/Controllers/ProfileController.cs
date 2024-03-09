using CroKnitters.Entities;
using CroKnitters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                        string userImageSrc = null;

                        // Check if the user has an ImageId
                        if (user.ImageId.HasValue)
                        {
                            // Find the image by ImageId and get the ImageSrc
                            var image = _db.Images.FirstOrDefault(i => i.ImageId == user.ImageId.Value);
                            if (image != null)
                            {
                                userImageSrc = image.ImageSrc;
                            }
                        }

                        // Prepare the view model
                        UserProfileViewModel viewModel = new UserProfileViewModel()
                        {
                            user = user,
                            UserImageSrc = userImageSrc 
                        };
                        return View("Index", viewModel);
                    }
                }
            }
            // If any of the cookies are missing, redirect to login

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            int userId = int.Parse(Request.Cookies["userId"]!);
            User user = _db.Users.Find(userId)!;

            string userImageSrc = null;

            // Check if the user has an ImageId
            if (user.ImageId.HasValue)
            {
                // Find the image by ImageId and get the ImageSrc
                var image = _db.Images.FirstOrDefault(i => i.ImageId == user.ImageId.Value);
                if (image != null)
                {
                    userImageSrc = image.ImageSrc;
                }
            }

            // Prepare the view model
            UserProfileViewModel viewModel = new UserProfileViewModel()
            {
                user = user,
                UserImageSrc = userImageSrc
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(UserProfileViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                // Log or inspect ModelState errors
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
                    }
                }

                Console.WriteLine("something went wrong");
                return View(userViewModel);
            }

            _db.Users.Update(userViewModel.user);
            _db.SaveChanges();

            return RedirectToAction("Index", "Profile");
        }

        private CrochetAppDbContext _db;

      
    }
}
