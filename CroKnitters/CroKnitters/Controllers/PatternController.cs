using CroKnitters.Entities;
using CroKnitters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CroKnitters.Controllers
{
    public class PatternController : Controller
    {
        public PatternController(CrochetAppDbContext crochetDbContext)
        {
            _crochetDbContext = crochetDbContext;
        }

        public IActionResult Index()
        {
            int userId = Int32.Parse(Request.Cookies["userId"]!);

            var allPatterns = _crochetDbContext.Patterns.Include(p => p.PatternImages)
                .Include(p => p.PatternComments)
                .Include(p => p.Owner)
                .OrderBy(p => p.PatternName)
                .Select(p => new PatternSummaryViewModel()
                {
                    ActivePattern = p,
                    NumberOfComments = p.PatternComments.Count(),
                    Images = p.PatternImages.Select(pi => pi.Image.ImageSrc).ToList()
                }).Where(p => p.ActivePattern.OwnerId == userId).ToList();

            if (allPatterns == null || allPatterns.Count == 0)
            {
                TempData["noPattern"] = "No patterns available";
            }
            return View(allPatterns);
        }

        [HttpGet]
        public IActionResult CreateNewPattern()
        {
            return View("CreatePattern");
        }


        //accept the request containing all the relevant details
        [HttpPost]
        public async Task<IActionResult> CreatePattern(PatternViewModel patternViewModel)
        {
            //get the current user id
            int userId = Int32.Parse(Request.Cookies["userId"]!);
            //ModelState.Remove("User");

            //check if there are no errors
            if (ModelState.IsValid)
            {

                //valid user
                if (userId != 0)
                {
                    patternViewModel.ActivePattern.CreationDate = DateTime.Now;
                    patternViewModel.ActivePattern.OwnerId = userId;
                    patternViewModel.ActivePattern.Owner = _crochetDbContext.Users.FirstOrDefault(o => o.UserId == userId);

                    UploadImages(patternViewModel);

                    //create a new tag for the pattern
                    if (patternViewModel.Tags != null && patternViewModel.Tags.Any())
                    {
                        //iterate through the list of tags
                        foreach (var tagName in patternViewModel.Tags)
                        {
                            //should split the tagname if there are more than one i.e tag1, tag2, tag3
                            //check if it exists
                            Tag? existingTag = _crochetDbContext.Tags.FirstOrDefault(t => t.TagName == tagName);

                            // Tag doesn't exist, create a new one                       
                            if (existingTag == null)
                            {
                                existingTag = new Tag { TagName = tagName };
                                _crochetDbContext.Tags.Add(existingTag);
                            }
                            else
                            {
                                // Tag already exists, associate with the pattern
                                patternViewModel.ActivePattern.PatternTags.Add(new PatternTag { Tag = existingTag });
                            }
                        }
                    }

                    //add the pattern
                    _crochetDbContext.Patterns.Add(patternViewModel.ActivePattern);
                    //save
                    await _crochetDbContext.SaveChangesAsync();

                    TempData["LastActionMessage"] = $"New Pattern \"{patternViewModel.ActivePattern.PatternName}\" was added.";
                    return RedirectToAction("Index", "Pattern");
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            else
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
                return View("CreatePattern", patternViewModel);
            }

        }

        public void UploadImages(PatternViewModel viewModel)
        {
            //handle image upload
            //check if there are images in the collection and they are not more than 2
            if (viewModel.Images != null && viewModel.Images.Count > 0 && viewModel.Images.Count <= 2)
            {
                //loop through the collection
                foreach (var image in viewModel.Images)
                {
                    var fileName = Path.GetFileName(image.FileName);

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\patterns", fileName);
                    Console.WriteLine("filepath for current picture: " + filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyToAsync(stream);

                        Console.WriteLine(stream);
                    }

                    //var imageSrc = Path.Combine("wwwroot/img/patterns", fileName);
                    var newImage = new Image { ImageSrc = fileName };
                    _crochetDbContext.Images.Add(newImage);
                    //var img = viewModel.ActivePattern.PatternImages.Select(i => i.Image = newImage);
                    viewModel.ActivePattern.PatternImages.Add(new PatternImage { Image = newImage });
                }

            }
            else
            {
                TempData["manyImages"] = "You can't upload more than 2 images";
            }
        }

        private int selectedPatternId = 0;
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            selectedPatternId = id;

            var patternViewModel = await _crochetDbContext.Patterns
                .Where(p => p.PatternId == id)
                .Include(p => p.PatternImages).ThenInclude(pi => pi.Image)
                .Include(p => p.PatternComments)
                .Include(p => p.PatternTags).ThenInclude(pt => pt.Tag)
                .FirstOrDefaultAsync();

            if (patternViewModel == null)
            {
                return NotFound();
            }

            // Check if the Owner is null
            if (patternViewModel.Owner == null)
            {
                // Fetch the owner details separately
                var owner = await _crochetDbContext.Users
                    .Where(u => u.UserId == patternViewModel.OwnerId)
                    .FirstOrDefaultAsync();

                // If owner is still null, handle accordingly (e.g., return an error view)
                if (owner == null)
                {
                    return NotFound("Owner not found");
                }

                patternViewModel.Owner = owner;
            }

            // Continue building the ViewModel
            var patternDetailViewModel = new PatternDetailViewModel
            {
                ActivePattern = patternViewModel,
                TagNames = patternViewModel.PatternTags.Select(pt => pt.Tag.TagName).ToList(),
                Images = patternViewModel.PatternImages
                    .Where(pi => pi.Image != null)
                    .Select(pi => pi.Image.ImageSrc)
                    .ToList(),
                Owner = patternViewModel.Owner.FirstName + " " + patternViewModel.Owner.LastName
            };

            // Get recommended patterns
            List<PatternSummaryViewModel> recommendedPatterns = GetRecommendedPatterns();
            ViewBag.RecommendedPatterns = recommendedPatterns;

            return View("PatternDetails", patternDetailViewModel);
        }

        public List<PatternSummaryViewModel> GetRecommendedPatterns()
        {
            List<PatternSummaryViewModel> recommendedpatterns = _crochetDbContext.Patterns.Include(p => p.PatternImages)
                .Include(p => p.PatternComments)
                .Include(p => p.Owner)
                .OrderBy(p => p.PatternName)
                .Select(p => new PatternSummaryViewModel()
                {
                    ActivePattern = p,
                    NumberOfComments = p.PatternComments.Count(),
                    Images = p.PatternImages.Select(pi => pi.Image.ImageSrc).ToList()
                }).OrderBy(g => Guid.NewGuid()).Where(p => p.ActivePattern.PatternId != selectedPatternId).Take(4).ToList();
            return recommendedpatterns;
        }


        [HttpGet]
        public async Task<IActionResult> EditPattern(int id)
        {
            //find the pattern with the id
            var existingPattern = await _crochetDbContext.Patterns
                .Include(p => p.PatternTags).ThenInclude(pt => pt.Tag)
                .Include(p => p.PatternImages)
                .FirstOrDefaultAsync(p => p.PatternId == id);

            //if the pattern exists
            if (existingPattern != null)
            {
                var tags = existingPattern.PatternTags.Select(pt => pt.Tag.TagName).ToList();
                PatternViewModel viewModel = new PatternViewModel()
                {
                    ActivePattern = existingPattern,
                    Tags = tags
                };

                return View(viewModel);
            }
            else return NotFound();

        }


        [HttpPost]
        public async Task<IActionResult> EditPattern(PatternViewModel patternViewModel)
        {
            if (ModelState.IsValid)
            {
                //find the pattern with the id
                var existingPattern = await _crochetDbContext.Patterns
                    .Include(p => p.PatternTags).ThenInclude(pt => pt.Tag)
                    .Include(p => p.PatternImages)
                    .FirstOrDefaultAsync(p => p == patternViewModel.ActivePattern);

                if (existingPattern == null)
                {
                    return NotFound();
                }

                // Clear existing tags
                existingPattern.PatternTags.Clear();

                // Iterate through the tags in the view model and update tags
                foreach (var tagName in patternViewModel.Tags)
                {
                    if (!string.IsNullOrEmpty(tagName))
                    {
                        // Check if the tag already exists
                        var existingTag = _crochetDbContext.Tags.FirstOrDefault(t => t.TagName == tagName);

                        if (existingTag == null)
                        {
                            // If the tag doesn't exist, create a new one
                            existingTag = new Tag { TagName = tagName };
                            _crochetDbContext.Tags.Add(existingTag);
                        }

                        // Create a new PatternTag and associate it with the pattern and tag
                        existingPattern.PatternTags.Add(new PatternTag { Tag = existingTag });
                    }
                }
                //_crochetDbContext.Patterns.Update(patternViewModel.ActivePattern);
                // Save changes to the database
                await _crochetDbContext.SaveChangesAsync();
                return RedirectToAction("Details", new { id = existingPattern.PatternId });
            }

            return View(patternViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeletePattern(int id, PatternViewModel patternViewModel)
        {
            // Find the pattern
            var pattern = await _crochetDbContext.Patterns
                    .Include(p => p.PatternTags).ThenInclude(pt => pt.Tag)
                    .Include(p => p.PatternImages)
                    .FirstOrDefaultAsync(p => p.PatternId == id);

            if (pattern == null)
            {
                return NotFound();
            }

            patternViewModel = new PatternViewModel()
            {
                ActivePattern = pattern
            };
            return View(patternViewModel);
        }



        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Find the pattern
            var pattern = await _crochetDbContext.Patterns
                    .Include(p => p.PatternTags).ThenInclude(pt => pt.Tag)
                    .Include(p => p.PatternImages)
                    .FirstOrDefaultAsync(p => p.PatternId == id);

            if (pattern == null)
            {
                return NotFound();
            }

            // Manually remove related entities
            _crochetDbContext.PatternTags.RemoveRange(pattern.PatternTags);
            _crochetDbContext.PatternImage.RemoveRange(pattern.PatternImages);

            // Remove the pattern
            _crochetDbContext.Patterns.Remove(pattern);
            await _crochetDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private CrochetAppDbContext _crochetDbContext;

    }
}
