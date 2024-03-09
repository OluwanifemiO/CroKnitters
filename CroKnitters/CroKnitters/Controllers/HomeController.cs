using CroKnitters.Entities;
using CroKnitters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CroKnitters.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, CrochetAppDbContext crochetDbContext)
        {
            _logger = logger;
            _crochetDbContext = crochetDbContext;
        }

        public IActionResult Index(string? search)
        {
            var feed = new Feed();

            
            var patternsQuery = _crochetDbContext.Patterns.AsQueryable();

            var projectsQuery = _crochetDbContext.Projects.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                patternsQuery = patternsQuery.Where(p => p.PatternName.Contains(search));
                projectsQuery = projectsQuery.Where(p => p.ProjectName.Contains(search));
            }

            var patterns = patternsQuery
                .Include(p => p.PatternImages)
                .Include(p => p.PatternComments)
                .Include(p => p.Owner)
                .Select(p => new PatternSummaryViewModel
                {
                    ActivePattern = p,
                    NumberOfComments = p.PatternComments.Count,
                    Images = p.PatternImages.Select(img => img.Image.ImageSrc).ToList() // Assuming ImageSrc is the path to the image
                }).ToList();

            var projects = projectsQuery
                .Include(p => p.ProjectImages)
                .Include(p => p.ProjectComments)
                .Select(p => new ProjectSummaryViewModel
                {
                    ActiveProject = p,
                    NumberOfComments = p.ProjectComments.Count,
                    Images = p.ProjectImages.Select(img => img.Image.ImageSrc).ToList() // Assuming ImageSrc is the path to the image
                }).ToList();

            feed.Patterns = patterns;
            feed.Projects = projects;

            return View(feed);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private CrochetAppDbContext _crochetDbContext;

    }
}