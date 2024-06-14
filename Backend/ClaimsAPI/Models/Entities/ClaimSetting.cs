using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entities;

public partial class ClaimSetting
{
    public Guid SettingsId { get; set; }

    public Guid? ClaimId { get; set; }

    public Guid? CompanyId { get; set; }

    public Guid? DocId { get; set; }

    public bool? IsRequired { get; set; }

    public virtual Claim? Claim { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ClaimDocument? Doc { get; set; }
}
