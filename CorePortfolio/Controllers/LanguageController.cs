using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Controllers
{
    [Route("languages")]
    [AllowAnonymous]
    public class LanguageController : Controller
    {
        [Route("change")]
        public IActionResult Change(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddMonths(1)
            });
            return LocalRedirect("/Dashboard/Index/");
        }

        [Route("changedefault")]
        public IActionResult ChangeDefault(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddMonths(1)
            });
            return LocalRedirect("/Default/Index/");
        }
    }
}
