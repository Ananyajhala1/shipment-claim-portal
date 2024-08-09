using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using ClaimsAPI.Service.RolesService;


namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        

    public class RolesController : ControllerBase
    {
        private IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }
        [HttpGet]
        //get all roles
        public async Task<ActionResult<IEnumerable<Role>>> GetRole()

        {
            var roles = await _rolesService.GetRole();
            if(roles == null)
            {
                return NotFound();
            }
            return Ok(roles);
        }
        //get single role


        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _rolesService.GetRoleById(id);
            if( role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }
       

        //create role
        [HttpPost("[action]")]
        public async Task<ActionResult<Role>> CreateRole(CreateUpdateRolesDTO roleDTO)
        {
            var role = await _rolesService.CreateRole(roleDTO);
            if(role == null)
            {
                return BadRequest();
            }        
            return Ok(role);
        }

        // Update role
        [HttpPut("[action]")]
        public async Task<ActionResult<Role>> UpdateRole(CreateUpdateRolesDTO rolesDTO,int id)
        {


            var role = await _rolesService.UpdateRole(id, rolesDTO);
            if(role.RoleId != id)
            {
                return BadRequest();
            }
            if(role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        // Delete role
        [HttpDelete("[action]")]
        public async Task<ActionResult<Role>> DeleteUser(int id)
        {
            var role = await _rolesService.DeleteRole(id);
            if(role == null)
            {
                return BadRequest();
            }
            return Ok(role);
        }


        // user role



        //get users from role
        [HttpGet("usersForRole")]

        public async Task<IActionResult> GetUsersInRole(int rid)
        {
            var usersInRole = await _rolesService.GetUserInRole(rid);
            if(usersInRole == null)
            {
                return NotFound();
            }
            return Ok(usersInRole);
        }

        // get roles from user
        [HttpGet("rolesForUser")]

        public async Task<IActionResult> GetRolesInUser(int uid)
        {

            var rolesInUser = await _rolesService.GetRolesInUser(uid);
            if(rolesInUser == null)
            {
                return NotFound();
            }
            return Ok(rolesInUser);
        }

        // creating user role

        [HttpPost("CreateUserRole")]
        public async Task<IActionResult> CreateUserRole(int uid , int rid)
        {


            var newUserRole = await _rolesService.CreateUserRole(uid, rid);
            if(newUserRole == null)
            {
                return NotFound();
            }
            return Ok(newUserRole);
        }

        // updating user role

        [HttpPut("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole(UpdateuserRoleDTO userRoleDTO)
        {
            var userRoleToUpdate = await _rolesService.UpdateUserRole(userRoleDTO);
            if (userRoleToUpdate == null)
            {
                return NotFound();
            }
            return Ok(userRoleToUpdate);
        }

        // delete user role
        [HttpDelete("DeleteUserRole/{userRoleId}")]
        public async Task<IActionResult> DeleteUserRole(int userRoleId)
        {
            var userRoleToDelete = await _rolesService.DeleteUserRole(userRoleId);
            if (userRoleToDelete == null)
            {
                return NotFound();
            }
            return Ok(userRoleToDelete);
        }
    }
}




