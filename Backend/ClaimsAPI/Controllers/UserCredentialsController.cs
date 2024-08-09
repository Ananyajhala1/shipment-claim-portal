using ClaimsAPI.Models.DTO.UserCredentialDTO;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Service.UserCredentialService;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCredentialsController : ControllerBase
    {
        private IUserCredentialService _userCredentialService;
        public UserCredentialsController(IUserCredentialService userCredentialService)
        {
            _userCredentialService = userCredentialService;
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<UserCredential>> CreateUserCredentials(int id, UserCredentialsPostDTO userCredentialsPostDTO)
        {
            var creds = await _userCredentialService.createUser(id, userCredentialsPostDTO);
            if(creds == null)
            {
                return BadRequest();
            }
            return Ok(creds);
        }
        [HttpPut("[action]")]
        public async Task<ActionResult<UserCredential>> UpdateUserCredentials(int id, UserCredentialsUpdateDTO userCredentialsUpdateDTO)
        {
            var creds = await _userCredentialService.updateUser(id, userCredentialsUpdateDTO);
            if(creds == null)
            {
                return BadRequest();
            }
            return Ok(creds);
        }

    }
}
