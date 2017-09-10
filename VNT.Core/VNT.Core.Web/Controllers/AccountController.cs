using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using VNT.Core.Business.Contract;
using VNT.Core.Model;
using VNT.Core.Web.Models;
using VNT.UI.Web.Models;

namespace VNT.UI.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserBusiness _userBusiness;

        public AccountController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

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
            var user = new User
            {
                Username = model.Username,
                Password = model.Password
            };
            if (_userBusiness.IsExisted(user))
            {
                var genericIdentity = new GenericIdentity(model.Username, DefaultAuthenticationTypes.ApplicationCookie);
                genericIdentity.AddClaims(new[]
                {
                    new Claim(ClaimTypes.Name, model.Username),
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
                if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(model.ReturnUrl);
            }
            ModelState.AddModelError("", "tk ko ton tai");
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            _userBusiness.Create(new User
            {
                Username = model.Username,
                Password = model.Password
            });
            return View("Login");
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }
    }
}