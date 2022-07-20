using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Areas.User.ViewComponents
{
    public class UserMail : ViewComponent
    {
        private readonly UserManager<SystemUser> _userManager;

        public UserMail(UserManager<SystemUser> userManager)
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
