using Microsoft.AspNetCore.Mvc;

namespace Crm.Mvc.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}