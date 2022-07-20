using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.ViewComponents.Dashboard
{
    public class DashboardMessages : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
