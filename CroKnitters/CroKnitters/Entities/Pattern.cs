using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CroKnitters.Entities;

public class Pattern
{
    public int PatternId { get; set; }

    [Required(ErrorMessage = "Pattern name is required")]
    public string PatternName { get; set; } = null!;

    [Required(ErrorMessage = "A description for this pattern is required")]
    public string? Description { get; set; }

    public DateTime CreationDate { get; set; }

    public int Likes { get; set; }

    public string? StitchType { get; set; }

    public int? StitchCount { get; set; }

    public int OwnerId { get; set; }

    public User? Owner { get; set; } = null!;

    public ICollection<PatternComment> PatternComments { get; set; } = new List<PatternComment>();

    public ICollection<PatternTag> PatternTags { get; set; } = new List<PatternTag>();

    public ICollection<ProjectPattern> ProjectPatterns { get; set; } = new List<ProjectPattern>();

    public ICollection<PatternImage> PatternImages { get; set; } = new List<PatternImage>();

    public ICollection<UserPattern> UserPatterns { get; set; } = new List<UserPattern>();
}
