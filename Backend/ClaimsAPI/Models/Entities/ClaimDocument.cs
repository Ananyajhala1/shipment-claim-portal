using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entites;
public partial class ClaimDocument
{
    public int DocId { get; set; }

    public int? ClaimId { get; set; }

    public int? DocTypeId { get; set; }

    public string DocumentUrl { get; set; }



    public virtual Claim? Claim { get; set; }

    public virtual ICollection<ClaimSetting> ClaimSettings { get; set; } = new List<ClaimSetting>();

    public virtual ClaimDocumentType? DocType { get; set; }
}
