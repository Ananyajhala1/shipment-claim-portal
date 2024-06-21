using System;
using System.Collections.Generic;

namespace ClaimsAPI.Models.Entities;

public partial class UserTemplate
{
    public int TemplateId { get; set; }

    public int? UserId { get; set; }

    public string? TemplateName { get; set; }

    public string? TemplateType { get; set; }

    public string? TemplateContent { get; set; }

    public virtual UserInfo? User { get; set; }
}
