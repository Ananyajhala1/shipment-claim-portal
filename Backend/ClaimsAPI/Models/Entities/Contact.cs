using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entities;

public partial class Contact
{
    public Guid ContactId { get; set; }

    public string? ContactName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public Guid? CompanyId { get; set; }

    public virtual Company? Company { get; set; }
}
