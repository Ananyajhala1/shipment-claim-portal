using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entities;

public partial class UserRole
{
    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual UserInfo? User { get; set; }
}
