using System;
using System.Collections.Generic;

namespace CroKnitters.Entities;

public class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public int? ProvinceId { get; set; }

    public Province? Province { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}
