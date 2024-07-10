using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Models.ViewModels
{
    public class GetRolesDTO
    {
        public int RoleId { get; set; }

        public string? RoleName { get; set; }


    }


    public class CreateUpdateRolesDTO
    {


      
        public string? RoleName { get; set; }


    }
}
