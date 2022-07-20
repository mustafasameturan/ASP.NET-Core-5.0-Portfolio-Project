using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.ViewComponents.Dashboard
{
    public class DashboardNavbarLogOut : ViewComponent
    {
        private readonly UserManager<SystemUser> _userManager;

        public DashboardNavbarLogOut(UserManager<SystemUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = values.ImageUrl;
            ViewBag.v2 = values.Name;
            return View(values);
        }
    }
}
