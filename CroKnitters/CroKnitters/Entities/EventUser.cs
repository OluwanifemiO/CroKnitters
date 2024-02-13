using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class EventUser
{
    public int EventUserId { get; set; }

    public int EventId { get; set; }

    public int UserId { get; set; }

    public Event Event { get; set; } = null!;

    public User User { get; set; } = null!;
}
