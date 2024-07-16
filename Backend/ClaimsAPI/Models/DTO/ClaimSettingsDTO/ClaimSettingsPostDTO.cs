using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Models.DTO.ClaimSettingsDTO
{
    public class ClaimSettingsPostDTO
    {

        public int ClaimId { get; set; }

        public int CompanyId { get; set; }

        public int DocId { get; set; }

        public bool? IsRequired { get; set; }

        
    }
}
