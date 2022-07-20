using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Areas.User.ViewComponents
{
    public class Language : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
