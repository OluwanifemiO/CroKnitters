using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class Language
{
    public int LanguageId { get; set; }

    public string LanguageName { get; set; } = null!;

    public ICollection<Preference> Preferences { get; set; } = new List<Preference>();
}
