using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entites;

public partial class ClaimStatus
{
    public int StatusId { get; set; }

    public string? StatusDesc { get; set; }

    public int ClaimId { get; set; }

    public virtual Claim? Claim { get; set; }

    public virtual ICollection<ClaimSubStatus> ClaimSubStatuses { get; set; } = new List<ClaimSubStatus>();
}
