using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class Image
{
    public int ImageId { get; set; }

    public string ImageSrc { get; set; } = null!;

    public ICollection<Pattern> Patterns { get; set; } = new List<Pattern>();

    public ICollection<Project> Projects { get; set; } = new List<Project>();

    public ICollection<User> Users { get; set; } = new List<User>();
}
