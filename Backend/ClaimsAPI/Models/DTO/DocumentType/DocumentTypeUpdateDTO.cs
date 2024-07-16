using ClaimsAPI.Models.Entites;
namespace ClaimsAPI.Models.DTO.DocumentType
{
    public class DocumentTypeUpdateDTO
    {
        public int DocTypeId { get; set; }

        public string? DoctypeDes { get; set; }

        public int? CompanyId { get; set; }

        

        
    }
}
