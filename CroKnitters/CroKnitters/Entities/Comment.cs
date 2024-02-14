using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class Comment
{
    public int CommentId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public int Likes { get; set; }

    public int OwnerId { get; set; }

    public User Owner { get; set; } = null!;

    public ICollection<PatternComment> PatternComments { get; set; } = new List<PatternComment>();

    public ICollection<ProjectComment> ProjectComments { get; set; } = new List<ProjectComment>();
}
