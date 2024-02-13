using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class Theme
{
    public int ThemeId { get; set; }

    public string ThemeTitle { get; set; } = null!;

    public ICollection<Preference> Preferences { get; set; } = new List<Preference>();
}
