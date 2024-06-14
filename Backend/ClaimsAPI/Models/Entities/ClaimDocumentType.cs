using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entities;

public partial class ClaimDocumentType
{
    public Guid DocTypeId { get; set; }

    public string? DoctypeDes { get; set; }

    public Guid? CompanyId { get; set; }

    public virtual ICollection<ClaimDocument> ClaimDocuments { get; set; } = new List<ClaimDocument>();

    public virtual Company? Company { get; set; }
}
