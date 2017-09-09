using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace VNT.UI.Web.Filters
{
    public class PermissionAttribute : AuthorizeAttribute
    {
        private readonly string[] _permissions;
        public PermissionAttribute(params string[] permissions)
        {
            _permissions = permissions;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var identity = (ClaimsIdentity) httpContext.GetOwinContext().Request.User.Identity;
            if (identity.IsAuthenticated)
            {
                var claims = identity.Claims;
                if (claims.Any(claim => claim.Type.Equals("/CustomClaim/Permission") &&
                                        _permissions.Any(permission => permission.Equals(claim.Value))))
                {
                    return true;
                }
            }
            return false;
        }
    }
}