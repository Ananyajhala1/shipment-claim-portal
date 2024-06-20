using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimsAPI.Models.Entities;

public partial class UserRole
{
     [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserRoleId { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

   
    public virtual Role Role { get; set; }

    public virtual UserInfo User { get; set; }
}
