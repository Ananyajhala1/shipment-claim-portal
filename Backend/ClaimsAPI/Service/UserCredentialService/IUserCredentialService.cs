using ClaimsAPI.Models.DTO.UserCredentialDTO;
using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Service.UserCredentialService
{
    public interface IUserCredentialService
    {
        Task<UserCredential> createUser(int id, UserCredentialsPostDTO user);
        Task<UserCredential> updateUser(int id, UserCredentialsUpdateDTO user);
    }
}
