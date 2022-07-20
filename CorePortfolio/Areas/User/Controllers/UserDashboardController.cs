using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PortfolioCoreProject.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    [Route("User/[controller]/[action]")]
    public class UserDashboardController : Controller
    {
        private readonly UserManager<SystemUser> _userManager;
        private Context c;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public UserDashboardController(UserManager<SystemUser> userManager, Context c, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _userManager = userManager;
            this.c = c;
            _sharedLocalizer = sharedLocalizer;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = value.Name + " " + value.Surname;

            //Weather Api
            string api = "f672904cce85285a1839acda567fb6a7";
            string lang = _sharedLocalizer["weather"].ToString();
            string connectionStart = "http://api.openweathermap.org/data/2.5/weather?q=Istanbul&mode=xml&lang=";
            string connectionContinue = "&units=metric&appid=" + api;
            string connectionLast = connectionStart + lang + connectionContinue;
            XDocument document = XDocument.Load(connectionLast);
            ViewBag.weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.cloud = document.Descendants("clouds").ElementAt(0).Attribute("name").Value;
            ViewBag.city = document.Descendants("city").ElementAt(0).Attribute("name").Value;

            //statistics
            ViewBag.v1 = c.UserMessages.Where(x => x.Receiver == value.Email).Count();
            ViewBag.v2 = c.Announcements.Count();
            ViewBag.v3 = c.Users.Count();

            return View();
        }
    }
}
