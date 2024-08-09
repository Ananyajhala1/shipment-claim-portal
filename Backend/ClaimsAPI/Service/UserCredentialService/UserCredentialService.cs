using ClaimsAPI.Models;
using ClaimsAPI.Models.DTO.UserCredentialDTO;
using ClaimsAPI.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAPI.Service.UserCredentialService
{
    public class UserCredentialService : IUserCredentialService
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;

        public UserCredentialService(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }
        public async Task<UserCredential> createUser(int id, UserCredentialsPostDTO user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var user_info = await shipmentClaimsContext.UserInfos.FirstOrDefaultAsync(u => u.UserId == id);
            if(user_info == null)
            {
                throw new ArgumentNullException(nameof(user_info));
            }
            var userCreds = new UserCredential
            {
                UserId = id,
                UserName = user.UserName,
                Password = user.Password
            };
            await shipmentClaimsContext.UserCredentials.AddAsync(userCreds);
            await shipmentClaimsContext.SaveChangesAsync();
            return userCreds;
        }
        public async Task<UserCredential> updateUser(int id, UserCredentialsUpdateDTO user)
        {
            var credsToUpdate = await shipmentClaimsContext.UserCredentials.FirstOrDefaultAsync(u => u.UserId == id);
            if (credsToUpdate == null)
            {
                throw new ArgumentNullException(nameof(credsToUpdate));
            }
            credsToUpdate.UserId = id;
            credsToUpdate.Password = user.Password;
            shipmentClaimsContext.UserCredentials.Update(credsToUpdate);
            await shipmentClaimsContext.SaveChangesAsync();
            return credsToUpdate;
        }
    }
}
