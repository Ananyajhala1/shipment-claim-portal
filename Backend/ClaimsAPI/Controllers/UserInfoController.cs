using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;

using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using ClaimsAPI.Service.UserInfoService;
using System.Security.Cryptography;


namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _UserInfoService;
        public UserInfoController(IUserInfoService userInfoService)
        {
            _UserInfoService = userInfoService;
        }
        [HttpGet]
        //get all users
        public async Task<IActionResult> GetUserInfo(int? pageNumber, int? pageSize)

        {
            var UserInfoService = await  _UserInfoService.GetUserInfo(pageNumber, pageSize);
            if (UserInfoService == null)
            {
                return NotFound();
            }
            return Ok(UserInfoService);
        }
        //get all users by companyId


        [HttpGet("[action]")]
        public async Task<IActionResult> CompanyUsers(int cid)
        {
            var UserInfoService = await _UserInfoService.CompanyUsers(cid);
            if (UserInfoService == null)
            {
                return NotFound();
            }
            return Ok(UserInfoService);
        }
    
    //get a single user

    [HttpGet("[action]")]
    public async Task<IActionResult> UserDetails(int userId)
        {
            var UserInfoService = await _UserInfoService.UserDetails(userId);
            if (UserInfoService == null)
            {
                return NotFound();
            }
            return Ok(UserInfoService);
        }


        //create user
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserInfoDTO userInfoDTO)
        {
            var UserInfoService = await _UserInfoService.CreateUser(userInfoDTO);
            if (UserInfoService == null)
            {
                return NotFound();
            }
            return Ok(UserInfoService);

        }

        // Update an existing user
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUser( UpdateUserInfoDTO userInfoDTO)
        {
            var UserInfoService = await _UserInfoService.UpdateUser(userInfoDTO); 
            if (UserInfoService == null)
            {
                return NotFound();
            }
            return Ok(UserInfoService);



        }

        // Delete a user
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteUser(UpdateUserInfoDTO userInfoDTO)
        {
            var UserInfoService = await _UserInfoService.DeleteUser(userInfoDTO);
            if (UserInfoService == null)
            {
                return NotFound();
            }
            return Ok(UserInfoService);
        }



    }
}




