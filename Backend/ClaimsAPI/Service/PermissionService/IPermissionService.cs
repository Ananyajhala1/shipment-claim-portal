using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsAPI.Service.PermissionService
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetPermissions();
        Task<Permission> GetPermissionByID(int id);
        Task<Permission> CreatePermission(CreateUpdatePermissionDTO permissionDTO);
        Task<Permission> UpdatePermission(int id, CreateUpdatePermissionDTO permissionDTO);
        Task<Permission> DeletePermission(int id);
    }
}
