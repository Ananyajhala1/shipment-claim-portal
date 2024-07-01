namespace ClaimsAPI.Models.ViewModels
{
    public class GetuserRoleDTO
    {
        public int UserId { get; set; }
        public string? RoleName { get; set; }
        public int RoleId { get; set; }
           public string? FirstName { get; set; }

    }

    public class UpdateuserRoleDTO
    {

        public int UserRoleId { get; set; }
        public int UserId { get; set; }


        public int RoleId { get; set; }

    }






}
