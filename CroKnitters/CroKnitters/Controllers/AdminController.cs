using CroKnitters.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CroKnitters.Controllers
{
    public class AdminController : Controller
    {
        public AdminController(CrochetAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult AdminLogin()
        {
            return View();
        }

        //let admin log in
        [HttpPost]
        public IActionResult LoginAccess(string username, string password)
        {
            string? failedAttempt = HttpContext.Session.GetString("FailedAttemps")?.ToString();
            int failedAttemptNo = 0;
            if (failedAttempt == null)
            {
                HttpContext.Session.SetString("FailedAttemps", "0");
            }
            else
            {
                failedAttemptNo = Int32.Parse(failedAttempt);
            }

            if (failedAttemptNo > 3)
            {
                TempData["error"] = "Consecutive failed attempts Try again";
                HttpContext.Session.SetString("FailedAttemps", "0");
                return RedirectToAction("AdminLogin", "Admin");
            }


            if (username != null && password != null)
            {
                // sucess login
                Admin? admin = _dbContext.Admin.Where(u => u.Username == username).FirstOrDefault();

                if (admin == null)
                {
                    failedAttemptNo++;
                    HttpContext.Session.SetString("FailedAttemps", failedAttemptNo.ToString());
                    TempData["error"] = "email or password incorrect";
                    return RedirectToAction("AdminLogin", "Admin");
                }

                if (admin.Password != password)
                {
                    failedAttemptNo++;
                    HttpContext.Session.SetString("FailedAttemps", failedAttemptNo.ToString());
                    TempData["error"] = "email or password incorrect";
                    return RedirectToAction("AdminLogin", "Admin");
                }

                HttpContext.Session.SetString("FailedAttemps", "0");
                HttpContext.Session.SetString("role", "admin");
                //admin role cookie
                Response.Cookies.Append("role", "admin", new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddHours(1), // Set expiration time 1h
                    HttpOnly = true // Ensures the cookie is not accessible through JavaScript
                });
                //admin id cookie
                HttpContext.Session.SetString("adminId", admin.AdminId.ToString());
                Response.Cookies.Append("adminId", admin.AdminId.ToString(), new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddHours(1), // Set expiration time 1h
                    HttpOnly = true // Ensures the cookie is not accessible through JavaScript
                });

                return View("Homepage");
            }

            return RedirectToAction("AdminLogin", "Admin");
        }

        private CrochetAppDbContext _dbContext;

       
    }
}
