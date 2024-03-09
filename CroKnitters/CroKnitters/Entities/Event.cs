using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class Event
{
    public int EventId { get; set; }

    public string EventTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public int OwnerId { get; set; }

    public ICollection<EventUser> EventUsers { get; set; } = new List<EventUser>();

    public User Owner { get; set; } = null!;
}
