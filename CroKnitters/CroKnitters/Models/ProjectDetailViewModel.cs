using CroKnitters.Entities;

namespace CroKnitters.Models
{
    public class ProjectDetailViewModel
    {
        public Project ActiveProject { get; set; }

        public List<string> TagNames { get; set; }

        //public List<PatternComment> Comments { get; set; }

        public List<string> Images { get; set; }

        public string Owner { get; set; }
    }
}
