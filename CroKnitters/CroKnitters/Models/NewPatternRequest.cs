using CroKnitters.Entities;
using System.ComponentModel.DataAnnotations;

namespace CroKnitters.Models
{
    public class NewPatternRequest
    {
        public int? PatternId { get; set; }

        public string PatternName {  get; set; }

        public string? Description {  get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public string? StitchType { get; set; }

        public int? StitchCount { get; set; }

        public string? TagName {  get; set; }

        [Range(0,2)]
        public IFormFile? Images { get; set; }
    }
}
