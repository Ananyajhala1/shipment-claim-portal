using ClaimsAPI.Models.Entities;

namespace ClaimsAPI.Models.ViewModels
{
    public class GetRolePermissionDTO
    {


        public int PermissionId { get; set; }
      
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? PermissionDescription { get; set; }
        public bool? AllowClient { get; set; }
        public bool? AllowCarrier { get; set; }
        public bool? AllowInsurance { get; set; }


    }



    public class UpdateRolePermissionDTO
    {


        public int Id { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }

    


    }
}
