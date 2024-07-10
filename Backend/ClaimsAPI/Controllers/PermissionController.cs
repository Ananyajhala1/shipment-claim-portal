using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using System.Threading.Tasks;
using System.Linq;
using ClaimsAPI.Service.PermissionService;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private IPermissionService _permissionService;
        private IPermissionRoleService _permissionRoleService;
        public PermissionsController(IPermissionService permissionServie, IPermissionRoleService permissionRoleService)
        {
            _permissionService = permissionServie;
            _permissionRoleService = permissionRoleService;
        }

        // GET: api/Permissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permission>>> GetPermissions()
        {
            var permissions = await _permissionService.GetPermissions();
            if (permissions == null)
            {
                return NotFound();
            }
            return Ok(permissions);
        }

        // GET: api/Permissions/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Permission>> GetPermission(int id)
        {
            var permission = await _permissionService.GetPermissionByID(id);
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
            var permission = await _permissionService.CreatePermission(permissionDTO);
            if (permission == null)
            {
                return NotFound();
            }
            return Ok(permission);
        }

        // PUT: api/Permissions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermission(int id, CreateUpdatePermissionDTO permissionDTO)
        {
            var permission = await _permissionService.UpdatePermission(id, permissionDTO);
            if (permission.PermissionId != id)
            {
                return BadRequest();
            }
            if (permission == null)
            {
                return NotFound();
            }
            return Ok(permission);
        }

        // DELETE: api/Permissions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            var permission = await _permissionService.DeletePermission(id);
            if (permission == null)
            {
                return NotFound();
            }
            return Ok(permission);
        }

        // get permission by roles

        [HttpGet("PermissionsForRole")]
        public async Task<IActionResult> GetPermissionForRole(int rid)
        {
            var permissionForRole = await _permissionRoleService.GetPermissionsForRole(rid);
            if (permissionForRole == null)
            {
                return NotFound();
            }
            return Ok(permissionForRole);
        }


        // get permissions for Allow Clients
        [HttpGet("PermissionForClients")]
        public async Task<IActionResult> GetPermissionForCLient()
        {
            var permissionsForClient = await _permissionRoleService.GetPermissionsForClient();
            if (permissionsForClient == null)
            {
                return NotFound();
            }
            return Ok(permissionsForClient);
        }


        // get permissions for Insurance
        [HttpGet("PermissionForInsuarance")]
        public async Task<IActionResult> GetPermissionForInsurance()
        {
            var permissionForInsurance = await _permissionRoleService.GetPermissionsForInsurance();
            if (permissionForInsurance == null)
            {
                return NotFound();
            }
            return Ok(permissionForInsurance);
        }
        // get permissions for Insurance
        [HttpGet("PermissionForCarrier")]
        public async Task<IActionResult> GetPermissionForCarrier()
        {
            var permissionsForCarrier = await _permissionRoleService.GetPermissionsForCarrier();
            if (permissionsForCarrier == null)
            {
                return NotFound();
            }
            return Ok(permissionsForCarrier);
        }

        // create role permission
        [HttpPost("createRolePermission")]
        public async Task<IActionResult> CreateRolePermission(int rid, int pid)
        {
            var newRolePermission = await _permissionRoleService.CreateRolePermission(rid, pid);
            if (newRolePermission == null)
            {
                return NotFound();
            }
            return Ok(newRolePermission);
        }

        // updating role Permission

        [HttpPut("UpdateRolePermission")]
        public async Task<IActionResult> UpdateRolePermission(UpdateRolePermissionDTO RolePermissionDTO)
        {
            var RolePermissionToUpdate = _permissionRoleService.UpdateRolePermission(RolePermissionDTO);
            if (RolePermissionToUpdate == null)
            {
                return NotFound();
            }
            return Ok(RolePermissionToUpdate);
        }

        // delete RP
        [HttpDelete("DeleteRolePermission")]
        public async Task<IActionResult> DeleteRolePermission(int Id)
        {
            var RolePermissionToDelete = await _permissionRoleService.DeleteRolePermission(Id);
            if (RolePermissionToDelete == null)
            {
                return NotFound();
            }
            return Ok(RolePermissionToDelete);

        }
    }
}
