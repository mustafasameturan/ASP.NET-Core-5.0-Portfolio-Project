using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.ViewComponents.Admin
{
    public class AdminMailList : ViewComponent
    {
        private readonly UserManager<SystemUser> _userManager;

        public AdminMailList(UserManager<SystemUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _userManager.Users;
            return View(values);
        }
    }
}
