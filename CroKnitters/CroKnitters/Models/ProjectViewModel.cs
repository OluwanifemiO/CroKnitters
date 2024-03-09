using CroKnitters.Entities;

namespace CroKnitters.Models
{
    public class ProjectViewModel
    {
        public Project ActiveProject { get; set; }

        public string? Tags { get; set; }

        public IFormFileCollection? Images { get; set; }

        public int OwnerId { get; set; }
    }
}
