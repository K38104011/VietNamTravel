using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using VNT.UI.Web.Models;

namespace VNT.UI.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // https://stackoverflow.com/questions/31584506/how-to-implement-custom-authentication-in-asp-net-mvc-5
        // https://stackoverflow.com/questions/37086645/how-to-set-asp-net-identity-cookies-expires-time
        // https://stackoverflow.com/questions/31946582/how-ispersistent-works-in-owin-cookie-authentication
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var claimsIdentity = new ClaimsIdentity
            (new[] { new Claim(ClaimTypes.Name, model.UserName) },
                DefaultAuthenticationTypes.ApplicationCookie
            );
            HttpContext.GetOwinContext().Authentication.SignIn(
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                },
                claimsIdentity
            );
            return View();
        }
    }
}