using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class Preference
{
    public int PreferenceId { get; set; }

    public int UserId { get; set; }

    public int LanguageId { get; set; }

    public int ThemeId { get; set; }

    public Language Language { get; set; } = null!;

    public Theme Theme { get; set; } = null!;

    public User User { get; set; } = null!;
}
