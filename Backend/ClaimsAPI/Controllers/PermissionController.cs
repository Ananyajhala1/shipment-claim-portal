using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClaimsAPI.Models;
using ClaimsAPI.Models.Entities;
using ClaimsAPI.Models.ViewModels;
using System.Threading.Tasks;
using System.Linq;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly ShipmentClaimsContext _dbContext;
        
        public PermissionsController(ShipmentClaimsContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Permissions
        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var permissions = await _dbContext.Permissions
                .Select(p => new GetPermissionsDTO
                {
                    PermissionId = p.PermissionId,
                    PermissionDescription = p.PermissionDescription,
                    AllowClient = p.AllowClient,
                    AllowCarrier = p.AllowCarrier,
                    AllowInsurance = p.AllowInsurance
                }).ToListAsync();

            return Ok(permissions);
        }

        // GET: api/Permissions/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermission(int id)
        {
            var permission = await _dbContext.Permissions
                .Where(p => p.PermissionId == id)
                .Select(p => new GetPermissionsDTO
                {
                    PermissionId = p.PermissionId,
                    PermissionDescription = p.PermissionDescription,
                    AllowClient = p.AllowClient,
                    AllowCarrier = p.AllowCarrier,
                    AllowInsurance = p.AllowInsurance
                }).FirstOrDefaultAsync();

            if (permission == null)
            {
                return NotFound();
            }

            return Ok(permission);
        }

        // POST: api/Permissions
        [HttpPost]
        public async Task<IActionResult> CreatePermission(CreateUpdatePermissionDTO permissionDTO)
        {
            if (permissionDTO == null)
            {
                return BadRequest("Permission is null.");
            }

            var permission = new Permission
            {
                PermissionDescription = permissionDTO.PermissionDescription,
                AllowClient = permissionDTO.AllowClient,
                AllowCarrier = permissionDTO.AllowCarrier,
                AllowInsurance = permissionDTO.AllowInsurance
            };

            _dbContext.Permissions.Add(permission);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPermission), new { id = permission.PermissionId }, permissionDTO);
        }

        // PUT: api/Permissions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermission(int id, CreateUpdatePermissionDTO permissionDTO)
        {
            var permissionToUpdate = await _dbContext.Permissions.FindAsync(id);
            if (permissionToUpdate == null)
            {
                return NotFound("Permission not found.");
            }

            permissionToUpdate.PermissionDescription = permissionDTO.PermissionDescription;
            permissionToUpdate.AllowClient = permissionDTO.AllowClient;
            permissionToUpdate.AllowCarrier = permissionDTO.AllowCarrier;
            permissionToUpdate.AllowInsurance = permissionDTO.AllowInsurance;

            _dbContext.Permissions.Update(permissionToUpdate);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Permissions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            var permission = await _dbContext.Permissions.FindAsync(id);
            if (permission == null)
            {
                return NotFound("Permission not found.");
            }

            _dbContext.Permissions.Remove(permission);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        
        // get permission by roles

        [HttpGet("PermissionsForRole")]
        public async Task<IActionResult> GetPermissionForRole(int rid)
        {
            var permission = await _dbContext.RolePermissions
                .Where(p => p.RoleId == rid)
                .Select(p => new GetRolePermissionDTO
                {
                    RoleId =p.RoleId,
                    PermissionId =p.PermissionId,
                    PermissionDescription =p.Permission.PermissionDescription,
                    AllowCarrier = p.Permission.AllowCarrier,
                    AllowClient = p.Permission.AllowClient,
                    AllowInsurance = p.Permission.AllowInsurance

                   
                }).ToListAsync();

            if (permission == null)
            {
                return NotFound();
            }

            return Ok(permission);
        }
        

        // get permissions for Allow Clients
        [HttpGet("PermissionForClients")]
        public async Task<IActionResult> GetPermissionForCLient()
        {
            var permission = await _dbContext.RolePermissions
                .Where(p => p.Permission.AllowClient == true)
                .Select(p => new GetRolePermissionDTO
                {
                  
                    PermissionId = p.PermissionId,
                    PermissionDescription = p.Permission.PermissionDescription


                }).ToListAsync();

            if (permission == null)
            {
                return NotFound();
            }

            return Ok(permission);
        }
        

        // get permissions for Insurance
        [HttpGet("PermissionForInsuarance")]
        public async Task<IActionResult> GetPermissionForInsurance()
        {
            var permission = await _dbContext.RolePermissions
                .Where(p => p.Permission.AllowInsurance == true)
                .Select(p => new GetRolePermissionDTO
                {

                    PermissionId = p.PermissionId,
                    PermissionDescription = p.Permission.PermissionDescription


                }).ToListAsync();

            if (permission == null)
            {
                return NotFound();
            }

            return Ok(permission);
        }
        // get permissions for Insurance
        [HttpGet("PermissionForCarrier")]
        public async Task<IActionResult> GetPermissionForCarrier()
        {
            var permission = await _dbContext.RolePermissions
                .Where(p => p.Permission.AllowCarrier == true)
                .Select(p => new GetRolePermissionDTO
                {

                    PermissionId = p.PermissionId,
                    PermissionDescription = p.Permission.PermissionDescription


                }).ToListAsync();

            if (permission == null)
            {
                return NotFound();
            }

            return Ok(permission);
        }
        
        // create role permission
        [HttpPost("createRolePermission")]
        public async Task<IActionResult> CreateRolePermission(int rid,int pid)
        {
            if (rid == 0 || pid ==0)
            {
                return BadRequest("role Permsission data is null.");
            }

            var existingPermissionRole = await _dbContext.RolePermissions
                .FirstOrDefaultAsync(ur => ur.RoleId == rid && ur.PermissionId == pid);

            if (existingPermissionRole != null)
            {
                return Conflict(" Permission  role association already exists.");
            }

            var newPermissionRole = new RolePermission
            {
                RoleId = rid,
                PermissionId = pid

            };

            _dbContext.RolePermissions.Add(newPermissionRole);
            await _dbContext.SaveChangesAsync();

            return Ok(newPermissionRole);
        }

        // updating role Permission
        
        [HttpPut("UpdateRolePermission")]
        public async Task<IActionResult> UpdateRolePermission(UpdateRolePermissionDTO RolePermissionDTO)
        {
            if (RolePermissionDTO == null)
            {
                return BadRequest("roleP data is null.");
            }

            var RPToUpdate = await _dbContext.RolePermissions.FindAsync(RolePermissionDTO.Id);

            if (RPToUpdate == null)
            {
                return NotFound("User roleP association not found.");
            }

            // Check if the specified UserId or RoleId has changed
            if (RPToUpdate.RoleId != RolePermissionDTO.RoleId || RPToUpdate.PermissionId != RolePermissionDTO.PermissionId)
            {
                // Check if there is already an existing user role association with the new UserId and RoleId
                var existingRP = await _dbContext.RolePermissions
                    .FirstOrDefaultAsync(ur => ur.RoleId == RolePermissionDTO.RoleId && ur.PermissionId == RolePermissionDTO.PermissionId);

                if (existingRP != null && existingRP.Id != RolePermissionDTO.Id)
                {
                    return Conflict("Role permission association already exists for the new PId and RoleId.");
                }
            }

            // Update user role association with new UserId and RoleId
            RPToUpdate.RoleId = RolePermissionDTO.RoleId;
            RPToUpdate.PermissionId = RolePermissionDTO.PermissionId;

            _dbContext.RolePermissions.Update(RPToUpdate);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        
        // delete RP
        [HttpDelete("DeleteRolePermission")]
        public async Task<IActionResult> DeleteRolePermission(int Id)
        {
            var RPToDelete = await _dbContext.RolePermissions.FindAsync(Id);

            if (RPToDelete == null)
            {
                return NotFound("role Permission association not found.");
            }

            _dbContext.RolePermissions.Remove(RPToDelete);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }


       

    }
}
