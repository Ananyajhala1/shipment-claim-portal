using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entities;

public partial class ClaimDocument
{
    public int DocId { get; set; }

    public int ClaimId { get; set; }

    public int DocTypeId { get; set; }

    public byte[]? Document { get; set; }

    public virtual Claim? Claim { get; set; }

    public virtual ICollection<ClaimSetting> ClaimSettings { get; set; } = new List<ClaimSetting>();

    public virtual ClaimDocumentType? DocType { get; set; }
}
