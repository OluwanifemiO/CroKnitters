using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class UserPattern
{
    public int UpatId { get; set; }

    public int UserId { get; set; }

    public int PatternId { get; set; }

    public Pattern Pattern { get; set; } = null!;

    public User User { get; set; } = null!;
}
