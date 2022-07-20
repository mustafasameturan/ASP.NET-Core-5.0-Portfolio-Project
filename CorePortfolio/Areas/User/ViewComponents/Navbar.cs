using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Areas.User.ViewComponents
{
    public class Navbar : ViewComponent
    {
        private readonly UserManager<SystemUser> _userManager;

        public Navbar(UserManager<SystemUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = value.ImageUrl;
            return View(value);
        }
    }
}
