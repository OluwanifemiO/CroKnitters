using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class ProjectTag
{
    public int ProTagId { get; set; }

    public int ProjectId { get; set; }

    public int TagId { get; set; }

    public Project Project { get; set; } = null!;

    public Tag Tag { get; set; } = null!;
}
