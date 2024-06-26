﻿using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entites;

public partial class ClaimSubStatus
{
    public int SubStatusId { get; set; }

    public int? StatusId { get; set; }

    public int CompanyId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ClaimStatus? Status { get; set; }
}
