using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
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
            var genericIdentity = new GenericIdentity(model.UserName, DefaultAuthenticationTypes.ApplicationCookie);
            genericIdentity.AddClaims(new[]
            {
                new Claim(ClaimTypes.Name, model.UserName),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim("/CustomClaim/Permission", "Contact"), 
            });
            HttpContext.GetOwinContext().Authentication.SignIn(
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                },
                genericIdentity
            );
            Thread.CurrentPrincipal = new ClaimsPrincipal(genericIdentity);
            return Redirect(model.ReturnUrl);
        }
    }
}