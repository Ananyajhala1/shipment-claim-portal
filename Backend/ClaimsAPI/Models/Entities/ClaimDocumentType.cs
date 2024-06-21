using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entities;

public partial class ClaimDocumentType
{
    public int DocTypeId { get; set; }

    public string? DoctypeDes { get; set; }

    public int CompanyId { get; set; }

    public virtual ICollection<ClaimDocument> ClaimDocuments { get; set; } = new List<ClaimDocument>();

    public virtual Company? Company { get; set; }
}
