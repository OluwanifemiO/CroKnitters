using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class ProjectPattern
{
    public int ProPatId { get; set; }

    public int ProjectId { get; set; }

    public int PatternId { get; set; }

    public Pattern Pattern { get; set; } = null!;

    public Project Project { get; set; } = null!;
}
