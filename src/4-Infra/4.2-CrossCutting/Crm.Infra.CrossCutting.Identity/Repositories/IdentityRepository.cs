using Crm.Domain.Models.Permission;
using Crm.Infra.CrossCutting.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Crm.Infra.CrossCutting.Identity
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityRepository
        (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            return _roleManager.Roles;
        }

        public async Task<IEnumerable<string>> GetPermissionsByUser(ApplicationUser appUser)
        {
            return await _userManager.GetRolesAsync(appUser);
        }

        public async Task<IEnumerable<Claim>> GetClaimByRole(IdentityRole appRole)
        {
            return await _roleManager.GetClaimsAsync(appRole);
        }

        public async void AddRoleAsync(IdentityRole appRole)
        {
            await _roleManager.CreateAsync(appRole);
        }

        public void AddClaimToRole(IdentityRole appRole, IEnumerable<Claim> claims)
        {
            claims.ToList().ForEach(async x => await _roleManager.AddClaimAsync(appRole, x));
        }

        public async void AddUserToRoleAsync(ApplicationUser appUser, IdentityRole appRole)
        {
            await _userManager.AddToRoleAsync(appUser, appRole.Name);
        }
    }
}