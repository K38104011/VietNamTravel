using System.Web.Http;

namespace VNT.UI.Web.WebApi
{
    public class TestController : ApiController
    {
        [HttpGet]
        public string GetData()
        {
            return "Hello";
        }
    }
}
