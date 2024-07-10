using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAPI.Service.RolesService
{
    public class RolesService: IRolesService
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        public RolesService(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }
        public async Task<IEnumerable<Role>> GetRole()
        {
            var roles = await shipmentClaimsContext.Roles.ToListAsync();
            if(roles == null)
            {
                return Enumerable.Empty<Role>();
            }
            return roles;
        }
        public async Task<Role> GetRoleById(int id)
        {
            var role = await shipmentClaimsContext.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
            if(role == null)
            {
                throw new Exception($"role with id {id} does not exists");
            }
            return role;
        }
        public async Task<Role> CreateRole(CreateUpdateRolesDTO roleDTO)
        {
            if (roleDTO == null)
            {
                throw new Exception("Role is empty please enter valid values");
            }
            var role = new Role
            {
                RoleName = roleDTO.RoleName
            };
            await shipmentClaimsContext.Roles.AddAsync(role);
            await shipmentClaimsContext.SaveChangesAsync();
            return role;
        }
        public async Task<Role> UpdateRole(int id, CreateUpdateRolesDTO role)
        {
            var roleToUpdate = await shipmentClaimsContext.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
            if(roleToUpdate == null)
            {
                throw new Exception($"Role with id {id} not found");
            }
            roleToUpdate.RoleName = role.RoleName;
            shipmentClaimsContext.Roles.Update(roleToUpdate);
            await shipmentClaimsContext.SaveChangesAsync();
            return roleToUpdate;
        }
        public async Task<Role> DeleteRole(int id)
        {
            var role = await shipmentClaimsContext.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
            if(role == null)
            {
                throw new Exception($"role with role id: {id} not found");
                
            }
            shipmentClaimsContext.Roles.Remove(role);
            await shipmentClaimsContext.SaveChangesAsync();
            return role;
        }
        public async Task<IEnumerable<GetuserRoleDTO>> GetUserInRole(int rid)
        {
            var roles = await (from UserRole in shipmentClaimsContext.UserRoles.Where(x => x.RoleId == rid)
                               select new GetuserRoleDTO
                               {
                                   RoleId = UserRole.RoleId,
                                   RoleName = UserRole.Role.RoleName,
                                   UserId = UserRole.UserId,
                                   FirstName = UserRole.User.FirstName
                               }).ToListAsync();
            if (roles == null)
            {
                throw new Exception($"No user exists in role with id {rid}");
            }
            return roles;
        }
        public async Task<IEnumerable<GetuserRoleDTO>> GetRolesInUser(int uid)
        {
            var users = await (from UserRole in shipmentClaimsContext.UserRoles.Where(x => x.UserId == uid)
                               select new GetuserRoleDTO
                               {
                                   RoleId = UserRole.RoleId,
                                   RoleName = UserRole.Role.RoleName,
                                   UserId = UserRole.UserId,
                                   FirstName = UserRole.User.FirstName
                               }).ToListAsync();
            if (users == null)
            {
                throw new Exception($"User with userid {uid} has not been assigned any role");
            }
            return  users;
        }
        public async Task<UserRole> CreateUserRole(int uid, int rid)
        {
            var existingUserRole = await shipmentClaimsContext.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == uid && ur.RoleId == rid);
            if(existingUserRole != null)
            {
                throw new Exception($"User with id: {uid} has already been assigned to role with role id {rid}");
            }
            var userRole = new UserRole
            {
                UserId = uid,
                RoleId = rid
            };
            shipmentClaimsContext.UserRoles.Add(userRole);
            await shipmentClaimsContext.SaveChangesAsync();
             return userRole;
        }
        public async Task<UserRole> UpdateUserRole(UpdateuserRoleDTO userRoleDTO)
        {
            if (userRoleDTO == null)
            {
                throw new ArgumentNullException($"Can't update with null values");
            }
            var userRoletoUpdate = await shipmentClaimsContext.UserRoles.FindAsync(userRoleDTO.UserId);
            if(userRoletoUpdate != null)
            {
                throw new Exception($"No such user or role exists that you want to update");
            }
            if (userRoletoUpdate.UserId != userRoleDTO.UserId || userRoletoUpdate.RoleId != userRoleDTO.RoleId)
            {
                var existingUserRole = await shipmentClaimsContext.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == userRoleDTO.UserId && ur.RoleId == userRoleDTO.RoleId);
                if(existingUserRole != null && existingUserRole.UserRoleId != userRoleDTO.UserRoleId)
                {
                    throw new Exception($"user role association already exists for new userId {userRoleDTO.UserId}");
                }
            }
            userRoletoUpdate.UserId = userRoleDTO.UserId;
            userRoletoUpdate.RoleId = userRoleDTO.RoleId;
            shipmentClaimsContext.UserRoles.Update(userRoletoUpdate);
            await shipmentClaimsContext.SaveChangesAsync();
            return userRoletoUpdate;
        }
        public async Task<UserRole> DeleteUserRole(int userRoleId)
        {
            var userRoleToDelete = await shipmentClaimsContext.UserRoles.FindAsync(userRoleId);
            if (userRoleToDelete != null)
            {
                throw new Exception($"user role with id {userRoleId} does not exists");
            }
            shipmentClaimsContext.UserRoles.Remove(userRoleToDelete);
            await shipmentClaimsContext.SaveChangesAsync();
            return userRoleToDelete;
        }
    }
}
