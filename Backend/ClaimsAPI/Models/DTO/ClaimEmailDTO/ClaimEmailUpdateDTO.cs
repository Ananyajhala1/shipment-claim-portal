using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Models.DTO.ClaimEmailDTO
{
    public class ClaimEmailUpdateDTO
    {
        public string EmailId { get; set; } = null!;
        public string? Subject { get; set; }

        public string? Body { get; set; }
    }
}
