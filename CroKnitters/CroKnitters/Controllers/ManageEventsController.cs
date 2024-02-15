﻿using CroKnitters.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CroKnitters.Controllers
{
    public class ManageEventsController : Controller
    {
        private CrochetAppDbContext _dbContext;

        public ManageEventsController(CrochetAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            if (Request.Cookies.TryGetValue("role", out string role) && role == "admin")
            {
                if (Request.Cookies.TryGetValue("adminId", out string adminId))
                {
                    // Both "role" and "adminId" cookies exist
                    List<Event> events = _dbContext.Events.ToList();
                    return View(events);
                }
            }

            // If any of the cookies are missing or the role is not "admin", redirect to login
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Delete(int id)
        {
            Event @event = _dbContext.Events.Find(id);

            if (@event == null)
            {
                return HttpNotFound();
            }

            return View(@event);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = _dbContext.Events.Find(id);
            _dbContext.Events.Remove(@event);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}
