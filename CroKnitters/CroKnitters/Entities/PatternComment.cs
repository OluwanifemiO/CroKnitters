using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class PatternComment
{
    public int PatComId { get; set; }

    public int PatternId { get; set; }

    public int CommentId { get; set; }

    public Comment Comment { get; set; } = null!;

    public Pattern Pattern { get; set; } = null!;

    public Admin Admin { get; set; } = null!;
}
