using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Models.DTO.Claims
{
    public class ClaimUpdateDTO
    {
        public int ClaimId { get; set; }

        public DateOnly? FileDate { get; set; }

        public int? CustomerId { get; set; }

        public int? CarrierId { get; set; }

        public int? InsuranceId { get; set; }

    }
}
