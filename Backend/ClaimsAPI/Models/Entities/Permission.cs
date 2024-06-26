using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entites;

public partial class Permission
{
    public int PermissionId { get; set; }

    public string? PermissionDescription { get; set; }

    public bool? AllowClient { get; set; }

    public bool? AllowCarrier { get; set; }

    public bool? AllowInsurance { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
