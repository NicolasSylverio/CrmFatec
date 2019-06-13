using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Mvc.Controllers
{
    [Authorize]
    public class PermissionController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "User")]        
        [ValidateAntiForgeryToken]
        public IActionResult ListRoles()
        {
            return View("Index");
        }
    }
}