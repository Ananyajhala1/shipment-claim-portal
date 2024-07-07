using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;

namespace ClaimsAPI.Service.PermissionService
{
    public class PermissionRoleService : IPermissionRoleService
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        public PermissionRoleService(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }
        public async Task<IEnumerable<GetRolePermissionDTO>> GetPermissionsForRole(int rid)
        {
            var permissions = await shipmentClaimsContext.RolePermissions
                .Where(p => p.RoleId == rid)
                .Select(p => new GetRolePermissionDTO
                {
                    RoleId = p.RoleId,
                    PermissionId = p.PermissionId,
                    PermissionDescription = p.Permission.PermissionDescription,
                    AllowCarrier = p.Permission.AllowCarrier,
                    AllowClient = p.Permission.AllowClient,
                    AllowInsurance = p.Permission.AllowInsurance,
                }).ToListAsync();
            if (permissions == null)
            {
                throw new Exception($"this role is not granted any permissions");
            }
            return permissions;
        }
        public async Task<IEnumerable<GetRolePermissionDTO>> GetPermissionsForClient()
        {
            var permission = await shipmentClaimsContext.RolePermissions
                .Where(p => p.Permission.AllowClient == true)
                .Select(p => new GetRolePermissionDTO
                {
                    PermissionId = p.PermissionId,
                    PermissionDescription = p.Permission.PermissionDescription
                }).ToListAsync();
            if(permission == null)
            {
                return Enumerable.Empty<GetRolePermissionDTO>();
            }
            return permission;
        }
        public async Task<IEnumerable<GetRolePermissionDTO>> GetPermissionsForInsurance()
        {
            var permission = await shipmentClaimsContext.RolePermissions
                .Where(p => p.Permission.AllowInsurance == true)
                .Select(p => new GetRolePermissionDTO
                {
                    PermissionId = p.PermissionId,
                    PermissionDescription = p.Permission.PermissionDescription
                }).ToListAsync();
            if(permission== null)
            {
                return Enumerable.Empty<GetRolePermissionDTO>();
            }
            return permission;
        }
        public async Task<IEnumerable<GetRolePermissionDTO>> GetPermissionsForCarrier()
        {
            var permission = await shipmentClaimsContext.RolePermissions
                .Where(p => p.Permission.AllowCarrier == true)
                .Select(p => new GetRolePermissionDTO
                {
                    PermissionId = p.PermissionId,
                    PermissionDescription = p.Permission.PermissionDescription
                }).ToListAsync();
            if(permission== null)
            {
                return Enumerable.Empty<GetRolePermissionDTO>();
            }
            return permission;
            
        }
        public async Task<RolePermission> CreateRolePermission(int rid, int pid)
        {
            if(rid == 0 || pid == 0)
            {
                throw new ArgumentException("permission data is null");
            }
            var existingPermissionRole = await shipmentClaimsContext.RolePermissions.FirstOrDefaultAsync(rp => rp.PermissionId == pid && rp.RoleId == rid);
            if(existingPermissionRole != null)
            {
                throw new Exception("permission role association already exists");
            }
            var newPermissionRole = new RolePermission
            {
                RoleId = rid,
                PermissionId = pid,
            };
            shipmentClaimsContext.RolePermissions.Add(newPermissionRole);
            await shipmentClaimsContext.SaveChangesAsync();
            return newPermissionRole;

        }
        public async Task<RolePermission> UpdateRolePermission(UpdateRolePermissionDTO rolePermissionDTO)
        {
            if (rolePermissionDTO == null)
            {
                throw new Exception("Enter valid data for updation");
            }
            var RolePermissionToUpdate = await shipmentClaimsContext.RolePermissions.FirstOrDefaultAsync(rp => rp.PermissionId == rolePermissionDTO.PermissionId);
            if (RolePermissionToUpdate == null)
            {
                throw new Exception("No such association exists");
            }
            // check if the specified PermissionId and RoleId has changed
            if (RolePermissionToUpdate.RoleId != rolePermissionDTO.RoleId || RolePermissionToUpdate.PermissionId != rolePermissionDTO.PermissionId)
            {
                //check if there is already an existing user rol association with the new PermissionId and RoleId
                var existingPermissionRole = await shipmentClaimsContext.RolePermissions
                    .FirstOrDefaultAsync(ur => ur.RoleId == rolePermissionDTO.RoleId && ur.PermissionId == rolePermissionDTO.PermissionId);
                if (existingPermissionRole != null && existingPermissionRole.Id != rolePermissionDTO.Id)
                {
                    throw new Exception("role permission already exists for new permission and role id");
                }
            }
            RolePermissionToUpdate.RoleId = rolePermissionDTO.RoleId;
            RolePermissionToUpdate.PermissionId = rolePermissionDTO.PermissionId;
            shipmentClaimsContext.RolePermissions.Update(RolePermissionToUpdate);
            await shipmentClaimsContext.SaveChangesAsync();
            return RolePermissionToUpdate;
        }
        public async Task<RolePermission> DeleteRolePermission(int id)
        {
            var RolePermissionToDelete = await shipmentClaimsContext.RolePermissions.FirstOrDefaultAsync(rp => rp.Id == id);
            if (RolePermissionToDelete == null) {
                throw new Exception($"role permission association with id {id} does not exits");
            }
            shipmentClaimsContext.RolePermissions.Remove(RolePermissionToDelete);
            await shipmentClaimsContext.SaveChangesAsync();
            return RolePermissionToDelete;
        }


    }
}
