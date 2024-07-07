using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ClaimsAPI.Service.ClaimDocumentService
{
    public interface IClaimDocumentService
    {
        Task<IEnumerable<GetClaimDocumentDTO>> GetClaimDocuments(int cid);
        Task<ClaimDocument> GetClaimdDocumentById(int id);
        Task<ClaimDocument> CreateClaimDocument(CreateClaimDocumnentDTO claimDocumnentDTO);
        Task <ClaimDocument> DeleteClaimDocument(int id);
    }
}
