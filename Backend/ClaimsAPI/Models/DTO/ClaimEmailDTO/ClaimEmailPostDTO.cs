using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Models.DTO.ClaimEmailDTO
{
    public class ClaimEmailPostDTO
    {
        public string? Subject { get; set; }

        public string? Body { get; set; }

        public int? RecepientId { get; set; }

        public int? ClaimId { get; set; }

        public int? FromId { get; set; }

        public DateOnly? DateSent { get; set; }

        public virtual UserInfo? From { get; set; }

        public virtual Company? Recepient { get; set; }
    }
}
