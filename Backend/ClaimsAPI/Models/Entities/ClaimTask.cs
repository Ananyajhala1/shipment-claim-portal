using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entites;

public partial class ClaimTask
{
    public int TaskId { get; set; }

    public string? TaskDes { get; set; }

    public string? Status { get; set; }

    public int? UserId { get; set; }

    public int? ClaimId { get; set; }

    public DateOnly? DueDate { get; set; }

    public virtual Claim? Claim { get; set; }

    public virtual UserInfo? User { get; set; }
}
