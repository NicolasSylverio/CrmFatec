using Crm.Domain.Models.Permission;
using System.Collections.Generic;
using System.Security.Claims;

namespace Crm.Application.ViewModels.PermissionViewModels
{
    public class RoleViewModel
    {
        public RoleClaims IdentityRoleClaims { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}