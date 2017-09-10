using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http.Controllers;
using System.Web.Http;

namespace VNT.Security.CustomAttributes.WebApi
{
    public class PermissionAttribute : AuthorizeAttribute
    {
        private readonly string[] _permissions;
        public PermissionAttribute(params string[] permissions)
        {
            _permissions = permissions;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var controllerRequest = actionContext.ControllerContext.Request;
            var identity = (ClaimsIdentity) controllerRequest.GetOwinContext().Request.User
                .Identity;
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