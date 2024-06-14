using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entities;

public partial class ClaimEmail
{
    public string EmailId { get; set; } = null!;

    public string? Subject { get; set; }

    public string? Body { get; set; }

    public Guid? RecepientId { get; set; }

    public Guid? ClaimId { get; set; }

    public int? FromId { get; set; }

    public DateOnly? DateSent { get; set; }

    public virtual UserInfo? From { get; set; }

    public virtual Company? Recepient { get; set; }
}
