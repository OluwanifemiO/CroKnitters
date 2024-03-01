namespace CroKnitters.Entities
{
    public class Feed
    {
        public ICollection<Pattern> Patterns { get; set; } = new List<Pattern>();

        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
