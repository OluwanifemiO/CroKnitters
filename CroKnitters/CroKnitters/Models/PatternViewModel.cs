using Azure.Core;
using CroKnitters.Entities;
using System.ComponentModel.DataAnnotations;

namespace CroKnitters.Models
{
    public class PatternViewModel
    {
        public Pattern ActivePattern {  get; set; }

        public List<string>? Tags { get; set; }

        public IFormFileCollection? Images { get; set; }

        public int OwnerId {  get; set; } 
    }
}
