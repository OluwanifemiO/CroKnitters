using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class Pattern
{
    public int PatternId { get; set; }

    public string PatternName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreationDate { get; set; }

    public int Likes { get; set; }

    public string? StitchType { get; set; }

    public int? StitchCount { get; set; }

    public int OwnerId { get; set; }

    public int? ImageId { get; set; }

    public Image? Image { get; set; }

    public User Owner { get; set; } = null!;

    public ICollection<PatternComment> PatternComments { get; set; } = new List<PatternComment>();

    public ICollection<PatternTag> PatternTags { get; set; } = new List<PatternTag>();

    public ICollection<ProjectPattern> ProjectPatterns { get; set; } = new List<ProjectPattern>();

    public ICollection<UserPattern> UserPatterns { get; set; } = new List<UserPattern>();

    public Admin Admin { get; set; } = null!;
}
