using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ClaimsAPI.Models;
using ClaimsAPI.Models.Entities;


namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class RolesController : ControllerBase
    {
        private ShipmentClaimsContext _dbContext;


        [HttpGet]
        //get all users
        public async Task<IActionResult> GetUserInfo(int? pageNumber, int? pageSize)

        {
            int currentPageNumber = pageNumber ?? 1;
            var currentPageSize = pageSize ?? 1;
            var users = await (from user in _dbContext.UserInfos
                               select new
                               {
                                   Id = user.UserId,
                                   FName = user.FirstName,
                                   Lname = user.LastName,
                                   email = user.email,
                                   contact = user.ContactNumber
                               }).ToListAsync();

            return Ok(users.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize));
        }
        //get all users by companyId


        [HttpGet("[action]")]
        public async Task<IActionResult> CompanyUsers(Guid companyId)
        {
            var users = await _dbContext.UserInfos
                                      .Where(u => u.CompanyId == companyId)
                                      .ToListAsync();

            if (users == null || users.Count == 0)
            {
                return NotFound();
            }

            return Ok(users);
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

            return Ok(users);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                return BadRequest("User info is null.");
            }

            _dbContext.UserInfos.Add(userInfo);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(UserDetails), new { userId = userInfo.UserId }, userInfo);
        }

        // Update an existing user
        [HttpPut("[action]/{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, UserInfo userInfo)
        {
            if (userId != userInfo.UserId)
            {
                return BadRequest("User ID mismatch.");
            }

            var userToUpdate = await _dbContext.UserInfos.FindAsync(userId);
            if (userToUpdate == null)
            {
                return NotFound("User not found.");
            }

            userToUpdate.FirstName = userInfo.FirstName;
            userToUpdate.LastName = userInfo.LastName;
            userToUpdate.ContactNumber = userInfo.ContactNumber;
            userToUpdate.email = userInfo.email;
            userToUpdate.CompanyId = userInfo.CompanyId;

            _dbContext.UserInfos.Update(userToUpdate);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // Delete a user
        [HttpDelete("[action]/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _dbContext.UserInfos.FindAsync(userId);
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




