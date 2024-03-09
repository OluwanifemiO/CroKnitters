using CroKnitters.Entities;

namespace CroKnitters.Models
{
    public class ProjectSummaryViewModel
    {
        public Project ActiveProject { get; set; }

        public int NumberOfComments { get; set; }

        public List<string>? Images { get; set; }
    }
}
