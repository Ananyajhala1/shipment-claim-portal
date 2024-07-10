using ClaimsAPI.Models.DTO.Claims;
using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Service.claim
{
    public interface IClaim
    {
        Task<IEnumerable<Claim>> GetClaims();
        Task<Claim> GetClaimTypeById(int id);
        Task<Claim> AddClaim(ClaimPostDTO claim);
        Task<Claim> UpdateClaims(int id, ClaimUpdateDTO claim);
        Task<Claim> DeleteClaims(int id);
    }
}
