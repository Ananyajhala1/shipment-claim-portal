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

        public virtual Company? Carrier { get; set; }

        public virtual ICollection<ClaimDocument> ClaimDocuments { get; set; } = new List<ClaimDocument>();

        public virtual ICollection<ClaimSetting> ClaimSettings { get; set; } = new List<ClaimSetting>();

        public virtual ICollection<ClaimStatus> ClaimStatuses { get; set; } = new List<ClaimStatus>();

        public virtual ICollection<ClaimTask> ClaimTasks { get; set; } = new List<ClaimTask>();

        public virtual Company? Customer { get; set; }

        public virtual Company? Insurance { get; set; }
    }
}
