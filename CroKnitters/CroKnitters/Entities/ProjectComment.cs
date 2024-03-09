using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class ProjectComment
{
    public int ProComId { get; set; }

    public int ProjectId { get; set; }

    public int CommentId { get; set; }

    public Comment Comment { get; set; } = null!;

    public Project Project { get; set; } = null!;

    //public Admin Admin { get; set; } = null!;
}
