using Crm.Domain.Models.Permission;
using System.Collections.Generic;
using System.Security.Claims;

namespace Crm.Application.ViewModels.PermissionViewModels
{
    public class UserPermissionViewModel
    {
        public ApplicationUser IdentityUser { get; set; }

        public IEnumerable<RoleClaims> Roles { get; set; }

        public IEnumerable<Claim> Claims { get; set; }
    }
}