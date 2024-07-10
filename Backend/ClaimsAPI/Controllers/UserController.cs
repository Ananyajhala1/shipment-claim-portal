using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ShipmentClaimsContext shipmentClaimContext;

        public UserController (ShipmentClaimsContext shipmentClaimContext)
        {
            this.shipmentClaimContext = shipmentClaimContext;
        }

        [HttpGet("{id:int}/permissions")]

        public IActionResult GetUserPermissions(int id)
        {
            var user = shipmentClaimContext.UserInfos.FirstOrDefault(u => u.UserId == id);
            if(user == null)
            {
                
                return NotFound();
            }
            var userRoles = shipmentClaimContext.UserRoles.Where(user => user.UserId == id).Select(user => user.RoleId).ToList();
            if(userRoles == null || userRoles.Count == 0)
            {
                return BadRequest();
            }

            var permissions = shipmentClaimContext.RolePermissions.Where(rp => userRoles.Contains(rp.RoleId)).Select(rp => rp.Permission).Distinct().ToList();
            if(permissions == null || permissions.Count == 0)
            {
                return NotFound();
            }
            return Ok(permissions);
        }
    }
}
