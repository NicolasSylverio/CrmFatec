using Crm.Application.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Mvc.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ForgotPassword(ForgetPasswordViewModel forgetPassword)
        {
            if (!ModelState.IsValid)
            {
                return View(forgetPassword);
            }

            return View(nameof(ForgotPasswordSucess));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordSucess()
        {
            return View();
        }
    }
}