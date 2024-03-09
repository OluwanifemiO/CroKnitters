using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CroKnitters.Entities
{
    [Index(nameof(User.Username), IsUnique = true)]
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "The first name is required")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "The last name is required")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "The username is required")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "The Email is required")]
        [EmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "The password is required")]
        [StringLength(15, ErrorMessage = "Must be between 8 and 15 characters", MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$", ErrorMessage = "Password required at least lowercase, uppercase, special case and number\n Must be between 8 and 15 characters")]
        public string Password { get; set; } = null!;

        public string? Bio { get; set; }

        public int? CityId { get; set; }

        public int? ImageId { get; set; }

        public City? City { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<EventUser> EventUsers { get; set; } = new List<EventUser>();

        public ICollection<Event> Events { get; set; } = new List<Event>();

        public Image? Image { get; set; }

        public ICollection<Pattern> Patterns { get; set; } = new List<Pattern>();

        public ICollection<Preference> Preferences { get; set; } = new List<Preference>();

        public ICollection<Project> Projects { get; set; } = new List<Project>();

        public ICollection<UserPattern> UserPatterns { get; set; } = new List<UserPattern>();

        public ICollection<UserProject> UserProjects { get; set; } = new List<UserProject>();
    }
}
