using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;

namespace ClaimsAPI.Service.PermissionService
{
    public interface IPermissionRoleService
    {
        Task<IEnumerable<GetRolePermissionDTO>> GetPermissionsForRole(int rid);
        Task<IEnumerable<GetRolePermissionDTO>> GetPermissionsForClient();
        Task<IEnumerable<GetRolePermissionDTO>> GetPermissionsForInsurance();
        Task<IEnumerable<GetRolePermissionDTO>> GetPermissionsForCarrier();
        Task<RolePermission> CreateRolePermission(int rid, int pid);
        Task<RolePermission> UpdateRolePermission(UpdateRolePermissionDTO rolePermissionDTO);
        Task<RolePermission> DeleteRolePermission(int id);
    }
}
