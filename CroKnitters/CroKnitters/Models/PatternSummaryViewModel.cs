using CroKnitters.Entities;

namespace CroKnitters.Models
{
    public class PatternSummaryViewModel
    {
        //include pattern name, image, number of likes and comments
        public Pattern ActivePattern {  get; set; }

        public int NumberOfComments { get; set; }

        public List<string>? Images { get; set; }
    }
}
