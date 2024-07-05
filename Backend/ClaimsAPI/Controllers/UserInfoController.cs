using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;

using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;


namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserInfoController : ControllerBase
    {
        private ShipmentClaimsContext _dbContext;

        public UserInfoController(ShipmentClaimsContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        [HttpGet]
        //get all users
        public async Task<IActionResult> GetUserInfo(int? pageNumber, int? pageSize)

        {
            int currentPageNumber = pageNumber ?? 1;
            var currentPageSize = pageSize ?? 1;
            var users = await (from user in _dbContext.UserInfos
                                select new GetUserInfoDTO
                                {
                                   UserId = user.UserId,
                                   FirstName = user.FirstName,
                                    LastName = user.LastName,
                                    email = user.email,
                                    ContactNumber = user.ContactNumber
                                }).ToListAsync();

            return Ok(users.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize));
        }
        //get all users by companyId
       

        [HttpGet("[action]")]
        public async Task<IActionResult> CompanyUsers(int cid)
        {
            var users = await _dbContext.UserInfos
                                      .Where(u => u.CompanyId == cid)
                                      .ToListAsync();

            if (users == null || users.Count == 0)
            {
                return NotFound();
            }
            GetUserInfoDTO user = new GetUserInfoDTO();
            user.UserId = users[0].UserId;
            user.FirstName = users[0].FirstName;
            user.LastName = users[0].LastName;
            user.email = users[0].email; 
            user.ContactNumber = users[0].ContactNumber;    
            user.CompanyId = users[0].CompanyId;

            return Ok(user);
        }
        //get a single user

        [HttpGet("[action]")]
        public async Task<IActionResult> UserDetails(int userId)
        {
            var users = await _dbContext.UserInfos
                                      .Where(u => u.UserId == userId)
                                      .ToListAsync();

            if (users == null || users.Count == 0)
            {
                return NotFound();
            }
            GetUserInfoDTO user = new GetUserInfoDTO();
            user.UserId = users[0].UserId;
            user.FirstName = users[0].FirstName;
            user.LastName = users[0].LastName;
            user.email = users[0].email;
            user.ContactNumber = users[0].ContactNumber;
            user.CompanyId = users[0].CompanyId;


            return Ok(user);
        }

        //create user
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserInfoDTO userInfoDTO)
        {
            if (userInfoDTO == null)
            {

                return BadRequest("User info is null.");
            }
             UserInfo userInfo = new UserInfo();

            userInfo.FirstName = userInfoDTO.FirstName;
            userInfo.LastName = userInfoDTO.LastName;
            userInfo.email = userInfoDTO.email;
            userInfo.ContactNumber = userInfoDTO.ContactNumber;
            userInfo.CompanyId = userInfoDTO.CompanyId;

           
            _dbContext.UserInfos.Add(userInfo);
            await _dbContext.SaveChangesAsync();

            return Ok(userInfoDTO);
        }

        // Update an existing user
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUser( UpdateUserInfoDTO userInfoDTO)
        {
       

            var userToUpdate = await _dbContext.UserInfos.FindAsync(userInfoDTO.UserId);
            if (userToUpdate == null)
            {
                return NotFound("User not found.");
            }

            userToUpdate.FirstName = userInfoDTO.FirstName;
            userToUpdate.LastName = userInfoDTO.LastName;
            userToUpdate.ContactNumber = userInfoDTO.ContactNumber;
            userToUpdate.email = userInfoDTO.email;
            userToUpdate.CompanyId = userInfoDTO.CompanyId;

            _dbContext.UserInfos.Update(userToUpdate);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // Delete a user
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteUser(UpdateUserInfoDTO userInfoDTO)
        {
            var user = await _dbContext.UserInfos.FindAsync(userInfoDTO.UserId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            _dbContext.UserInfos.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }



    }
}




