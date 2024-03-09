using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreationDate { get; set; }

    public int Likes { get; set; }

    public string? Status { get; set; }

    public int OwnerId { get; set; }

    public int? ImageId { get; set; }

    public Image? Image { get; set; }

    public User Owner { get; set; } = null!;

    public ICollection<ProjectComment> ProjectComments { get; set; } = new List<ProjectComment>();

    public ICollection<ProjectPattern> ProjectPatterns { get; set; } = new List<ProjectPattern>();

    public ICollection<ProjectTag> ProjectTags { get; set; } = new List<ProjectTag>();

    public ICollection<UserProject> UserProjects { get; set; } = new List<UserProject>();

    public Admin Admin { get; set; } = null!;
}
