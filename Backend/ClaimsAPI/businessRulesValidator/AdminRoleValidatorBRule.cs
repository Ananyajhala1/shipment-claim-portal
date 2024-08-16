using ClaimsAPI.Models;
using ClaimsAPI.Service.RolesService;
using System.Runtime.CompilerServices;

namespace ClaimsAPI.businessRulesValidator
{
    public class AdminRoleValidatorBRule : BRuleBase
    {
        private readonly int _usrID;
        private readonly IRolesService _roleService;
        public AdminRoleValidatorBRule(ShipmentClaimsContext context, int id, IRolesService rolesService) : base(context) 
        {
            _usrID = id;
            _roleService = rolesService;
        }
        public override bool Execute()
        {
            var userRoles = _roleService.GetRolesInUser(_usrID).Result;
            var isAdmin = userRoles.Any(r => r.RoleID == 3);
            if(!isAdmin)
            {
                this.error = "You are not allowed to create role as you are not privilaged as a admin role";
                return false;
            }
            return true;
        }
    }
}
