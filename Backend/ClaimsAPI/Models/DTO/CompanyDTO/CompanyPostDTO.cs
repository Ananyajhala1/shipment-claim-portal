using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Models.DTO.CompanyDTO
{
    public class CompanyPostDTO
    {

        public int? CompanyTypeId { get; set; }

        public string CompanyName { get; set; } = null!;

        public bool IsCorporate { get; set; }

        public int? ParentCompanyId { get; set; }

        
    }
}
