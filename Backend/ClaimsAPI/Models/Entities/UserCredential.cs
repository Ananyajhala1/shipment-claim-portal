using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClaimsAPI.Models.Entites;

public partial class UserCredential
{
    public int UserId { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    [JsonIgnore]
    public virtual UserInfo User { get; set; } = null!;
}
