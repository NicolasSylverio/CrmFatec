using Crm.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Mvc.Controllers
{
    [Authorize]
    public class PermissionController : Controller
    {
        private readonly IPermissionAppService _permissionAppService;

        public PermissionController(IPermissionAppService permissionAppService)
        {
            _permissionAppService = permissionAppService;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult RolesList()
        {
            var roleList = _permissionAppService.ListAllRoles();

            return View(roleList);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult UserPermission()
        {


            return View();
        }
    }
}