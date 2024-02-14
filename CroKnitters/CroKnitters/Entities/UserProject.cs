using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class UserProject
{
    public int UproId { get; set; }

    public int UserId { get; set; }

    public int ProjectId { get; set; }

    public Project Project { get; set; } = null!;

    public User User { get; set; } = null!;
}
