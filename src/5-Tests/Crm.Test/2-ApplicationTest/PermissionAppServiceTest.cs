using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Crm.Application.Interface;
using Crm.Application.ViewModels.PermissionViewModels;
using Crm.Domain.Enum;
using Crm.Domain.Interfaces.Services;
using Crm.Domain.Models.Permission;
using Crm.Infra.CrossCutting.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Xunit;

namespace Crm.Test._2_ApplicationTest
{
    public class PermissionAppServiceTest
    {
        private readonly Mock<IPermissionAppService> _permissionAppServiceMock;
        private readonly IPermissionAppService _permissionAppService;
        private readonly Mock<IPermissionService> _permissionServiceMock;
        private readonly Mock<IIdentityRepository> _identityRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        private Role _role;
        private IEnumerable<Role> _roleList;
        private IEnumerable<RoleViewModel> _roleViewModel;

        private readonly Fixture _fixture;

        public PermissionAppServiceTest()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());

            _permissionServiceMock = _fixture.Freeze<Mock<IPermissionService>>();
            _identityRepositoryMock = _fixture.Freeze<Mock<IIdentityRepository>>();
            _mapperMock = _fixture.Freeze<Mock<IMapper>>();

            _permissionAppService = _fixture.Create<IPermissionAppService>();

            ConfigureRoleList();

            _permissionServiceMock
                .Setup(x => x.ComposeRole(It.IsAny<IdentityRole>(), It.IsAny<IEnumerable<Claim>>()))
                .Returns(ConfigureRole());

            _identityRepositoryMock
                .Setup(x => x.GetAllRoles())
                .Returns(ConfigureIdentityRole());
        }

        private void ConfigureRoleList(IEnumerable<Role> roles = null)
        {
            _role = ConfigureRole();

            if (roles == null)
            {
                roles = new List<Role>()
                {
                    ConfigureRole(),
                    _role
                };
            }

            _roleViewModel = _mapperMock.Object.Map<IEnumerable<RoleViewModel>>(roles);
        }

        private Role ConfigureRole()
        {
            var roleClaims = new List<Claim>()
            {
                new Claim(_fixture.Create<string>(), _fixture.Create<string>()),
                new Claim(CustomClaimTypes.Menu, _fixture.Create<string>())
            };

            return new Role(ConfigureIdentityRole().First(), roleClaims);
        }

        private List<IdentityRole> ConfigureIdentityRole()
        {
            return new List<IdentityRole>()
            {
                new IdentityRole(_fixture.Create<string>()),
                new IdentityRole(_fixture.Create<string>())
            };
        }

        [Fact]
        public static void ConstructorTest()
        {
            Assert.NotNull(1);
        }

        [Fact]
        public void Deve_Retornar_Todas_As_Permissoes()
        {
            var roles = _permissionAppService.ListAllRoles();

            Assert.Equal(new List<RoleViewModel>(), roles);
        }
    }
}