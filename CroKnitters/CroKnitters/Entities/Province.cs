using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class Province
{
    public int ProvinceId { get; set; }

    public string ProvinceName { get; set; } = null!;

    public ICollection<City> Cities { get; set; } = new List<City>();
}
