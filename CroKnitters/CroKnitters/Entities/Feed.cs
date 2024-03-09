using CroKnitters.Models;

namespace CroKnitters.Entities
{
    public class Feed
    {
        public ICollection<PatternSummaryViewModel> Patterns { get; set; } = new List<PatternSummaryViewModel>();

        public ICollection<ProjectSummaryViewModel> Projects { get; set; } = new List<ProjectSummaryViewModel>();

    }
}
