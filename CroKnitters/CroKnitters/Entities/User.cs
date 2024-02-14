namespace CroKnitters.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

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
