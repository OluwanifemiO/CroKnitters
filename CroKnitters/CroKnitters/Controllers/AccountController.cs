using CroKnitters.Entities;
using CroKnitters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Text;

namespace CroKnitters.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(CrochetAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //navigate to the login page
        public IActionResult Login()
        {
            return View();
        }

        //navigate to the sign up page
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([Bind("UserId,FirstName,LastName,Username,Email,Password,Bio")] User user)
        {
            //if there are errors
            if (!ModelState.IsValid)
            {
                return View("SignUp", user);
            }

            //if the user exists
            var existingUser = _dbContext.Users.Where(u => u.Username == user.Username).ToList();
            if (existingUser.Count != 0)
            {

                ModelState.AddModelError(nameof(user.Username), "User name is already registered");
                return View("SignUp", user);
            }

            //otherwise add them to the db
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();

            MailMessage msg = new MailMessage("croknittersinc@gmail.com", user.Email!,
               "CroKnitters account successfully created", "Hello there! \n You have successfully created a CroKnitters account. \n Have fun!");
            msg.SubjectEncoding = Encoding.UTF8;
            msg.BodyEncoding = Encoding.UTF8;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new System.Net.NetworkCredential("ogidamanifemi@gmail.com", "ydne jdhy vhif ewad");
            smtpClient.EnableSsl = true;

            smtpClient.Send(msg);
            msg.Dispose();

            TempData["error"] = "New Account Created Successfully.";

            return RedirectToAction("Login", "Account");
        }


        //let user login
        [HttpPost]
        public IActionResult UserLoginAccess(string username, string password)
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
                TempData["error"] = "Consecutive failed attempts, Try again";
                HttpContext.Session.SetString("FailedAttemps", "0");
                return RedirectToAction("Login", "Account");
            }


            if (username != null && password != null)
            {
                // sucess login
                //if the user with that username exists
                User? user = _dbContext.Users.Where(u => u.Username == username).FirstOrDefault();


                if (user == null)
                {
                    failedAttemptNo++;
                    HttpContext.Session.SetString("FailedAttemps", failedAttemptNo.ToString());
                    TempData["error"] = "email or password incorrect";
                    return RedirectToAction("Login", "Account");
                }

                if (user.Password != password)
                {
                    failedAttemptNo++;
                    HttpContext.Session.SetString("FailedAttemps", failedAttemptNo.ToString());
                    TempData["error"] = "email or password incorrect";
                    return RedirectToAction("Login", "Account");
                }

                HttpContext.Session.SetString("FailedAttemps", "0");
                HttpContext.Session.SetString("role", "user");
                //user role cookie
                Response.Cookies.Append("role", "user", new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddHours(1), // Set expiration time 1h
                    HttpOnly = true // Ensures the cookie is not accessible through JavaScript
                });
                //user id cookie
                HttpContext.Session.SetString("userId", user.UserId.ToString());
                Response.Cookies.Append("userId", user.UserId.ToString(), new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddHours(1), // Set expiration time 1h
                    HttpOnly = true // Ensures the cookie is not accessible through JavaScript
                });

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login", "Account");
        }

        //navigate to the Reset Password page
        public IActionResult Reset()
        {
            return View();
        }

        //reset password
        [HttpPost]
        public IActionResult PasswordReset(string email)
        {
            var user = _dbContext.Users.Where(u => u.Email == email).FirstOrDefault();
            if (user == null)
            {
                TempData["error"] = "That email does not exist";
                return View("Reset");
            }

            TempData["error"] = "New password has been sent to your email";

            MailMessage msg = new MailMessage("croknittersinc@gmail.com", user.Email!,
                "Your CroKnitters password has been changed", "Your new password is !a123456");
            msg.SubjectEncoding = Encoding.UTF8;
            msg.BodyEncoding = Encoding.UTF8;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new System.Net.NetworkCredential("ogidamanifemi@gmail.com", "ydne jdhy vhif ewad");
            smtpClient.EnableSsl = true;

            smtpClient.Send(msg);
            msg.Dispose();

            //awsClient.SendEmailAsync(sendRequest);

            user.Password = "!a123456";
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();

            return View("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            // Delete all cookies
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            return RedirectToAction("Login");
        }

        private CrochetAppDbContext _dbContext;


    }
}
