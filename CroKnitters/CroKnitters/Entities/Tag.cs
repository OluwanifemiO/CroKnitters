using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class Tag
{
    public int TagId { get; set; }

    public string TagName { get; set; } = null!;

    public ICollection<PatternTag> PatternTags { get; set; } = new List<PatternTag>();

    public ICollection<ProjectTag> ProjectTags { get; set; } = new List<ProjectTag>();
}
