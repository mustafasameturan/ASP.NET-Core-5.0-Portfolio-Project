using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.ViewComponents.Dashboard
{
    public class DashboardStatistics : ViewComponent
    {
        private Context c;

        public DashboardStatistics(Context c)
        {
            this.c = c;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Skills.Count();
            ViewBag.v2 = c.ContactMessages.Count();
            ViewBag.v3 = c.Experiences.Count();
            ViewBag.v4 = c.Services.Count();

            return View();
        }
    }
}
