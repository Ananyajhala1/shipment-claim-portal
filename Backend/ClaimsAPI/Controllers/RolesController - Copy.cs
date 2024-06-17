using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ClaimsAPI.Models;
using ClaimsAPI.Models.Entities;
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
            role.RoleId = temp[0].RoleId;
            role.RoleName = temp[0].RoleName;
          

            return Ok(role);
        }
       

        //create role
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole(GetRolesDTO roleDTO)
        {
            if (roleDTO == null)
            {

                return BadRequest("role is null.");
            }
               Role role = new Role();

            role.RoleId = roleDTO.RoleId;
            role.RoleName = roleDTO.RoleName;


            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();

        
            return Ok(roleDTO);
        }

        // Update role
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateRole(GetRolesDTO rolesDTO)
        {


            var roleToUpdate = await _dbContext.Roles.FindAsync(rolesDTO.RoleId);
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
        public async Task<IActionResult> DeleteUser(GetRolesDTO rolesDTO)
        {
            var role = await _dbContext.Roles.FindAsync(rolesDTO.RoleId);
            if (role == null)
            {
                return NotFound("role not found.");
            }

            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }



    }
}




