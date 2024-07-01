using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Models.ViewModels
{
    public class CreateUserInfoDTO
    {

  

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? ContactNumber { get; set; } 

        public string? email { get; set; }

        public int CompanyId { get; set; }



    }
}
