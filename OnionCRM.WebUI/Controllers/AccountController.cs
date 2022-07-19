using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnionCRM.Core.Domain;
using OnionCRM.WebUI.Areas.Identity.Pages.Account;
using LoginModel = OnionCRM.WebUI.Areas.Identity.Pages.Account.LoginModel;


namespace OnionCRM.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new LoginModel(_signInManager, _logger);
            
            return View("~/Areas/Identity/Pages/Account/Login.cshtml", model);
        }
    }
}
