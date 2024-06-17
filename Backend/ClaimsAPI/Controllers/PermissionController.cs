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
    }
}
