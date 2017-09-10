using System;
using System.Security.Claims;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace VNT.Security.Authentication
{
    public class CookieBaseAuthentication
    {
        private readonly IOwinContext _owinContext;
        private readonly ClaimsIdentity _identity;

        public ClaimsIdentity ClaimsIdentity
        {
            get { return _identity; }
        }

        public CookieBaseAuthentication(IOwinContext owinContext, ClaimsIdentity identity)
        {
            _owinContext = owinContext;
            _identity = identity;
        }

        public void SignIn()
        {
            _owinContext.Authentication.SignIn(
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                },
                _identity
            );
        }
    }
}
