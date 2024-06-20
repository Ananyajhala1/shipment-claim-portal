using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models;

public partial class UserCredential
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public virtual UserInfo User { get; set; } = null!;
}
