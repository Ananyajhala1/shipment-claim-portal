using ClaimsAPI.Models.DTO.ClaimEmailDTO;
using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Service.claimEmail
{
    public interface IClaimEmail
    {
        Task<IEnumerable<ClaimEmail>> GetClaimEmails();
        Task<ClaimEmail> GetClaimEmailsById(string id);
        Task<ClaimEmail> PostClaimEmail(ClaimEmailPostDTO claimEmail);
        Task<ClaimEmail> UpdateClaimEmail(string id, ClaimEmailUpdateDTO claimEmail);
        Task<ClaimEmail> DeleteClaimEmail(string id);
    }
}
