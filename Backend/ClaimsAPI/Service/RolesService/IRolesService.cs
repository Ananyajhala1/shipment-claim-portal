using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsAPI.Service.RolesService
{
    public interface IRolesService
    {
        Task<IEnumerable<Role>> GetRole();
        Task<Role> GetRoleById(int id);
        Task<Role> CreateRole(CreateUpdateRolesDTO role);
        Task<Role> UpdateRole(int id, CreateUpdateRolesDTO role);
        Task<Role> DeleteRole(int id);
        Task<IEnumerable<GetuserRoleDTO>> GetUserInRole(int rid);
        Task<IEnumerable<GetuserRoleDTO>> GetRolesInUser(int uid);
        Task<UserRole> CreateUserRole(int uid, int rid);
        Task<UserRole> UpdateUserRole(UpdateuserRoleDTO userRoleDTO);
        Task<UserRole> DeleteUserRole(int userRoleId);
    }
}
