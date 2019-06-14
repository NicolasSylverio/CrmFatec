using Crm.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Crm.Domain.Models.Permission;

namespace Crm.Infra.CrossCutting.Identity.Interfaces
{
    public interface IIdentityRepository
    {
        IEnumerable<IdentityRole> GetAllRoles();

        Task<IEnumerable<string>> GetPermissionsByUser(ApplicationUser appUser);

        Task<IEnumerable<Claim>> GetClaimByRole(IdentityRole appRole);

        void AddRoleAsync(IdentityRole appRole);

        void AddClaimToRole(IdentityRole appRole, IEnumerable<Claim> claims);

        void AddUserToRoleAsync(ApplicationUser appUser, IdentityRole appRole);
    }
}