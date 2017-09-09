using System.Net.Http;
using System.Web.Http;
using VNT.UI.Web.ApiFilters;

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
