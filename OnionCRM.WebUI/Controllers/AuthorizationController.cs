using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionCRM.Core.Domain;

namespace OnionCRM.WebUI.Controllers
{
    public class AuthorizationController : Controller
    {

        [AllowAnonymous]
        public IActionResult Authorize()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                
                Serilog.Log.Logger.Information("{UserName} logged in", User.Identity.Name);
                return RedirectToAction("Index", "Home");
               
            }
            else
            {
                Serilog.Log.Logger.Error("Not authenticated user tried to enter{Addr}",HttpContext.Connection.RemoteIpAddress.ToString());


                return RedirectToAction("Login", "Account");
            }
        }
    }
}
