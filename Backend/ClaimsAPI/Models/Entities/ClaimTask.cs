﻿using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entities;

public partial class ClaimTask
{
    public Guid TaskId { get; set; }

    public string? TaskDes { get; set; }

    public string? Status { get; set; }

    public int? UserId { get; set; }

    public Guid? ClaimId { get; set; }

    public DateOnly? DueDate { get; set; }

    public virtual Claim? Claim { get; set; }

    public virtual UserInfo? User { get; set; }
}