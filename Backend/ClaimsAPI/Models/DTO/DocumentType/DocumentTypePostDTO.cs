using ClaimsAPI.Models.Entites;
namespace ClaimsAPI.Models.DTO.DocumentType
{
    public class DocumentTypePostDTO
    {

        public string? DoctypeDes { get; set; }

        public int? CompanyId { get; set; }

        public virtual ICollection<ClaimDocument> ClaimDocuments { get; set; } = new List<ClaimDocument>();

        public virtual Company? Company { get; set; }
    }
}
