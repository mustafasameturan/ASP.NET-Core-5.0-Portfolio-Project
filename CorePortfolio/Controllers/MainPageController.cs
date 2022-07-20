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
    public class MainPageController : Controller
    {
        private IMainPageService _mainPageService;
        private readonly INotyfService _notyfService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public MainPageController(IMainPageService mainPageService, INotyfService notyfService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _mainPageService = mainPageService;
            _notyfService = notyfService;
            _sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = _mainPageService.GetById(1);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditMainPage(MainPage mainPage)
        {
            _mainPageService.Update(mainPage);
            _notyfService.Information(_sharedLocalizer["mainPageUpdated"].ToString());
            return LocalRedirect("/MainPage/Index/");
        }
    }
}
