using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Models.DTO.Claims
{
    public class ClaimUpdateDTO
    {
        public int ClaimId { get; set; }

        public virtual ICollection<ClaimDocument> ClaimDocuments { get; set; } = new List<ClaimDocument>();

        public virtual ICollection<ClaimSetting> ClaimSettings { get; set; } = new List<ClaimSetting>();

        public virtual ICollection<ClaimStatus> ClaimStatuses { get; set; } = new List<ClaimStatus>();

        public virtual ICollection<ClaimTask> ClaimTasks { get; set; } = new List<ClaimTask>();

    }
}
