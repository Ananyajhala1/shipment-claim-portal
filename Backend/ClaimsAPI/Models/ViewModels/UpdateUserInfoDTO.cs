using ClaimsAPI.Models.Entities;

namespace ClaimsAPI.Models.ViewModels
{
    public class UpdateUserInfoDTO
    {


        public int? UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? ContactNumber { get; set; }
        public Guid? CompanyId { get; set; }

        public string? email { get; set; }


    }
}
