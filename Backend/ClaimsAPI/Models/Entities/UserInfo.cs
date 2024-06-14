using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entities;

public partial class UserInfo
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public Guid? CompanyId { get; set; }

    public virtual ICollection<ClaimEmail> ClaimEmails { get; set; } = new List<ClaimEmail>();

    public virtual ICollection<ClaimTask> ClaimTasks { get; set; } = new List<ClaimTask>();

    public virtual Company? Company { get; set; }

    public virtual UserCredential? UserCredential { get; set; }

    public virtual ICollection<UserTemplate> UserTemplates { get; set; } = new List<UserTemplate>();
}
