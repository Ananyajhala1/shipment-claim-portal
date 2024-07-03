using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAPI.Service.PermissionService
{
    public class PermissionService : IPermissionService
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        public PermissionService(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }
        public async Task<IEnumerable<Permission>> GetPermissions()
        {
            var permissions = await shipmentClaimsContext.Permissions.ToListAsync();
            if (permissions == null)
            {
                return Enumerable.Empty<Permission>();
            }
            return permissions;
        }
        public async Task<Permission> GetPermissionByID(int id)
        {
            var permission = await shipmentClaimsContext.Permissions.FirstOrDefaultAsync(p => p.PermissionId == id);
            if (permission == null)
            {
                throw new Exception($"permission with id: {id} does not exits");
            }
            return permission;
        }
        public async Task<Permission> CreatePermission(CreateUpdatePermissionDTO permissionDTO)
        {
            if(permissionDTO == null)
            {
                throw new Exception($"values cant be null!!");
            }
            var permission = new Permission
            {
                PermissionDescription = permissionDTO.PermissionDescription,
                AllowClient = permissionDTO.AllowClient,
                AllowCarrier = permissionDTO.AllowCarrier,
                AllowInsurance = permissionDTO.AllowInsurance,
            };
            shipmentClaimsContext.Permissions.Add(permission);
            await shipmentClaimsContext.SaveChangesAsync();

            return permission;
        }
        public async Task<Permission> UpdatePermission(int id, CreateUpdatePermissionDTO permissionDTO)
        {
            var permissionToUpdate = await shipmentClaimsContext.Permissions.FirstOrDefaultAsync(p => p.PermissionId == id);
            if(permissionToUpdate == null)
            {
                throw new Exception($"permission with id {id} does not exists");
            }
            permissionToUpdate.PermissionDescription = permissionDTO.PermissionDescription;
            permissionToUpdate.AllowClient = permissionDTO.AllowClient;
            permissionToUpdate.AllowCarrier = permissionDTO.AllowCarrier;
            permissionToUpdate.AllowInsurance = permissionDTO.AllowInsurance;

            shipmentClaimsContext.Permissions.Update(permissionToUpdate);
            await shipmentClaimsContext.SaveChangesAsync();

            return permissionToUpdate;
        }
        public async Task<Permission> DeletePermission(int id)
        {
            var permission = await shipmentClaimsContext.Permissions.FirstOrDefaultAsync(p => p.PermissionId == id);
            if (permission == null)
            {
                throw new Exception($"permission with id {id} does not exists");
            }
            shipmentClaimsContext.Permissions.Remove(permission);
            await shipmentClaimsContext.SaveChangesAsync();
            return permission;
        }
    }
}
