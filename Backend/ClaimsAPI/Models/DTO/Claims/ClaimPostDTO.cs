using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Models.DTO.Claims
{
    public class ClaimPostDTO
    {

        public DateOnly? FileDate { get; set; }

        public int? CustomerId { get; set; }

        public int? CarrierId { get; set; }

        public int? InsuranceId { get; set; }

    }
}
