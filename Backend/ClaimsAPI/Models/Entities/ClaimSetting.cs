using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entities;

public partial class ClaimSetting
{
    public int SettingsId { get; set; }

    public int ClaimId { get; set; }

    public int CompanyId { get; set; }

    public int DocId { get; set; }

    public bool? IsRequired { get; set; }

    public virtual Claim? Claim { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ClaimDocument? Doc { get; set; }
}
