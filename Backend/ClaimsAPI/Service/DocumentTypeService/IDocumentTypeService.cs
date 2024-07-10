using ClaimsAPI.Models.DTO.DocumentType;
using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Service.DocumentTypeService
{
    public interface IDocumentTypeService
    {
        Task<IEnumerable<ClaimDocumentType>> GetDocumentTypes();
        Task<ClaimDocumentType> GetDocumentTypeByID(int id);
        Task<ClaimDocumentType> AddDocType(DocumentTypePostDTO cdt);
        Task<ClaimDocumentType> UpdateDocType(int id, DocumentTypeUpdateDTO cdt);
        Task<ClaimDocumentType> DeleteDocType(int id);

    }
}
