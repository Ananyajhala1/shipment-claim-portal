using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entities;

public partial class Location
{
    public Guid LocationId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public int? Zipcode { get; set; }

    public Guid? CompanyId { get; set; }

    public virtual Company? Company { get; set; }
}
