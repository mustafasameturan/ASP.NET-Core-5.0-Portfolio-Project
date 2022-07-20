using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private IAboutService _aboutService;
        private readonly INotyfService _notfyService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public AboutController(IAboutService aboutService, INotyfService notfyService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _aboutService = aboutService;
            _notfyService = notfyService;
            _sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = _aboutService.GetById(1);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditAbout(About about)
        {
            _aboutService.Update(about);
            _notfyService.Information(_sharedLocalizer["aboutMeUpdated"].ToString());
            return LocalRedirect("/About/Index/");
        }
    }
}
