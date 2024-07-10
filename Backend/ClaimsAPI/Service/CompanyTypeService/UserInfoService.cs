using ClaimsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using System.Data;

namespace ClaimsAPI.Service.UserInfoService
{
    public class UserInfoService: IUserInfoService

    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        public UserInfoService(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }
        // get all users 
        public  async Task<IList<GetUserInfoDTO>> GetUserInfo(int? pageNumber, int? pageSize)

        {
            int currentPageNumber = pageNumber ?? 1;
            var currentPageSize = pageSize ?? 1;
            var users = await  (from user in shipmentClaimsContext.UserInfos
                               select new GetUserInfoDTO
                               {
                                   UserId = user.UserId,
                                   FirstName = user.FirstName,
                                   LastName = user.LastName,
                                   email = user.email,
                                   ContactNumber = user.ContactNumber
                               }).ToListAsync< GetUserInfoDTO>();

            return users;
        }
        //get all users by companyId
        public async Task<IList<GetUserInfoDTO>> CompanyUsers(int cid)
        {
   

            var users2 =  await (from user in shipmentClaimsContext.UserInfos.Where(u => u.CompanyId == cid)
                               select new GetUserInfoDTO
                               {
                                   UserId = user.UserId,
                                   FirstName = user.FirstName,
                                   LastName = user.LastName,
                                   email = user.email,
                                   ContactNumber = user.ContactNumber
                               }).ToListAsync();

            return users2;
        }
        //get a single user
        public async Task<GetUserInfoDTO> UserDetails(int userId)
        {
            var users = await  shipmentClaimsContext.UserInfos
                                      .Where(u => u.UserId == userId)
                                      .ToListAsync();

            if (users == null || users.Count == 0)
            {
                throw new Exception($" users is null");
            }
            GetUserInfoDTO user = new GetUserInfoDTO();
            user.UserId = users[0].UserId;
            user.FirstName = users[0].FirstName;
            user.LastName = users[0].LastName;
            user.email = users[0].email;
            user.ContactNumber = users[0].ContactNumber;
            user.CompanyId = users[0].CompanyId;


            return user;
        }

        //create user
     
        public async Task<CreateUserInfoDTO> CreateUser(CreateUserInfoDTO userInfoDTO)
        {
            if (userInfoDTO == null)
            {

                throw new Exception($" users is null");
            }
            UserInfo userInfo = new UserInfo();

            userInfo.FirstName = userInfoDTO.FirstName;
            userInfo.LastName = userInfoDTO.LastName;
            userInfo.email = userInfoDTO.email;
            userInfo.ContactNumber = userInfoDTO.ContactNumber;
            userInfo.CompanyId = userInfoDTO.CompanyId;


            shipmentClaimsContext.UserInfos.Add(userInfo);
            await shipmentClaimsContext.SaveChangesAsync();

            return userInfoDTO;
        }
        // Update an existing user
    
        public async Task<UpdateUserInfoDTO> UpdateUser(UpdateUserInfoDTO userInfoDTO)
        {


            var userToUpdate = await shipmentClaimsContext.UserInfos.FindAsync(userInfoDTO.UserId);
            if (userToUpdate == null)
            {
                throw new Exception($" users is null");
            }

            userToUpdate.FirstName = userInfoDTO.FirstName;
            userToUpdate.LastName = userInfoDTO.LastName;
            userToUpdate.ContactNumber = userInfoDTO.ContactNumber;
            userToUpdate.email = userInfoDTO.email;
            userToUpdate.CompanyId = userInfoDTO.CompanyId;

            shipmentClaimsContext.UserInfos.Update(userToUpdate);
            await shipmentClaimsContext.SaveChangesAsync();

            return userInfoDTO;
        }
        // Delete a user
     
        public async Task<UpdateUserInfoDTO> DeleteUser(UpdateUserInfoDTO userInfoDTO)
        {
            var user = await shipmentClaimsContext.UserInfos.FindAsync(userInfoDTO.UserId);
            if (user == null)
            {
               throw new Exception($" users is null");
            }

            shipmentClaimsContext.UserInfos.Remove(user);
            await shipmentClaimsContext.SaveChangesAsync();

            return userInfoDTO;
        }

    }
}
