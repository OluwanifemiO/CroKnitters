using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class PatternTag
{
    public int PatTagId { get; set; }

    public int PatternId { get; set; }

    public int TagId { get; set; }

    public Pattern Pattern { get; set; } = null!;

    public Tag Tag { get; set; } = null!;
}
