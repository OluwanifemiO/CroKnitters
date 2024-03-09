using CroKnitters.Entities;
using CroKnitters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CroKnitters.Controllers
{
    public class EventsController : Controller
    {  
        
        public EventsController(CrochetAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var events = _dbContext.Events.Include(e => e.EventUsers).ToList();

            EventViewModel viewModel = new EventViewModel() 
            { 
                Events = events
            };
            return View(viewModel);
        }

        private CrochetAppDbContext _dbContext;


    }
}
