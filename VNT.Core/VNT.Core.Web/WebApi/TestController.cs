using System.Web.Http;
using VNT.Security.CustomAttributes.WebApi;

namespace VNT.UI.Web.WebApi
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Permission("Contact")]
        public string GetData()
        {
            return "Hello";
        }
    }
}
