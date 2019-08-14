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
            var consultaUsuarioViewModel = _permissionAppService.ListAllUsers();

            return View(consultaUsuarioViewModel);
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

        public IActionResult Edit()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Remove()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Alterar()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Details()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}