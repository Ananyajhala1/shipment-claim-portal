using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;


namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class RolesController : ControllerBase
    {
        private ShipmentClaimsContext _dbContext;

        public RolesController(ShipmentClaimsContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        [HttpGet]
        //get all roles
        public async Task<IActionResult> GetRole()

        {
            var roles = await (from role in _dbContext.Roles
                               select new GetRolesDTO
                               {
                                RoleId = role.RoleId,
                                RoleName = role.RoleName
                               }).ToListAsync();

            return Ok(roles);
        }
        //get single role


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            var temp = await _dbContext.Roles
                                      .Where(u => u.RoleId == id)
                                      .ToListAsync();

            if (temp == null || temp.Count == 0)
            {
                return NotFound();
            }
            GetRolesDTO role = new GetRolesDTO();
            role.RoleId = id;
            role.RoleName = temp[0].RoleName;
          

            return Ok(role);
        }
       

        //create role
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole(CreateUpdateRolesDTO roleDTO)
        {
            if (roleDTO == null)
            {

                return BadRequest("role is null.");
            }
               Role role = new Role();

            role.RoleName = roleDTO.RoleName;


            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();

        
            return Ok(roleDTO);
        }

        // Update role
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateRole(CreateUpdateRolesDTO rolesDTO,int id)
        {


            var roleToUpdate = await _dbContext.Roles.FindAsync(id);
            if (roleToUpdate == null)
            {
                return NotFound("role not found.");
            }

            roleToUpdate.RoleName = rolesDTO.RoleName;
          

            _dbContext.Roles.Update(roleToUpdate);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // Delete role
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound("role not found.");
            }

            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }


        // user role



        //get users from role
        [HttpGet("usersForRole")]

        public async Task<IActionResult> GetUsersInRole(int rid)
        {

            var roles = await (from UserRole in _dbContext.UserRoles.Where(x => x.RoleId == rid)
                               select new GetuserRoleDTO
                               {
                                   RoleId = UserRole.RoleId,
                                   RoleName =UserRole.Role.RoleName,
                                   UserId = UserRole.UserId,
                                   FirstName = UserRole.User.FirstName


                               }).ToListAsync();

            if (roles == null || roles.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(roles);
        }

        // get roles from user
        [HttpGet("rolesForUser")]

        public async Task<IActionResult> GetRolesInUser(int uid)
        {

            var users = await (from UserRole in _dbContext.UserRoles.Where(x=>x.UserId == uid)
                            select new GetuserRoleDTO
                               {
                                   RoleId = UserRole.RoleId,
                                   RoleName = UserRole.Role.RoleName,
                                   UserId = UserRole.UserId,
                                   FirstName = UserRole.User.FirstName


                               }).ToListAsync();

            if (users == null || users.Count == 0)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // creating user role

        [HttpPost("CreateUserRole")]
        public async Task<IActionResult> CreateUserRole(int uid , int rid)
        {
         

            var existingUserRole = await _dbContext.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == uid && ur.RoleId == rid);

            if (existingUserRole != null)
            {
                return Conflict("User role association already exists.");
            }

            var newUserRole = new UserRole
            {
                UserId = uid,
                RoleId = rid
            };

            _dbContext.UserRoles.Add(newUserRole);
            await _dbContext.SaveChangesAsync();

            return Ok(newUserRole);
        }

        // updating user role

        [HttpPut("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole(UpdateuserRoleDTO userRoleDTO)
        {
            if (userRoleDTO == null)
            {
                return BadRequest("User role data is null.");
            }

            var userRoleToUpdate = await _dbContext.UserRoles.FindAsync(userRoleDTO.UserRoleId);

            if (userRoleToUpdate == null)
            {
                return NotFound("User role association not found.");
            }

            // Check if the specified UserId or RoleId has changed
            if (userRoleToUpdate.UserId != userRoleDTO.UserId || userRoleToUpdate.RoleId != userRoleDTO.RoleId)
            {
                // Check if there is already an existing user role association with the new UserId and RoleId
                var existingUserRole = await _dbContext.UserRoles
                    .FirstOrDefaultAsync(ur => ur.UserId == userRoleDTO.UserId && ur.RoleId == userRoleDTO.RoleId);

                if (existingUserRole != null && existingUserRole.UserRoleId != userRoleDTO.UserRoleId)
                {
                    return Conflict("User role association already exists for the new UserId and RoleId.");
                }
            }

            // Update user role association with new UserId and RoleId
            userRoleToUpdate.UserId = userRoleDTO.UserId;
            userRoleToUpdate.RoleId = userRoleDTO.RoleId;

            _dbContext.UserRoles.Update(userRoleToUpdate);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // delete user role
        [HttpDelete("DeleteUserRole/{userRoleId}")]
        public async Task<IActionResult> DeleteUserRole(int userRoleId)
        {
            var userRoleToDelete = await _dbContext.UserRoles.FindAsync(userRoleId);

            if (userRoleToDelete == null)
            {
                return NotFound("User role association not found.");
            }

            _dbContext.UserRoles.Remove(userRoleToDelete);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }




    }
}




