using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entites;

public partial class Location
{
    public int LocationId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public int? Zipcode { get; set; }

    public int? CompanyId { get; set; }

    public virtual Company? Company { get; set; }
}
