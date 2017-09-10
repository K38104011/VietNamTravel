using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace VNT.Core.Web.Controllers
{
    public class LanguageController : Controller
    {
        [HttpGet]
        public ActionResult ChangeLanguage(string selectedLanguage)
        {
            if (selectedLanguage == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
            var cookie = new HttpCookie("Language")
            {
                Value = selectedLanguage
            };
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home");
        }
    }
}