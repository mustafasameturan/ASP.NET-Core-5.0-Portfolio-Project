using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]   
    public class AnnouncementController : Controller
    {
        private readonly UserManager<SystemUser> _userManager;
        private IAnnouncementService _announcementService;
        private readonly INotyfService _notfyService;
        private AnnouncementValidator _validator;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public AnnouncementController(IAnnouncementService announcementService, UserManager<SystemUser> userManager, INotyfService notfyService, AnnouncementValidator validator, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _announcementService = announcementService;
            _userManager = userManager;
            _notfyService = notfyService;
            _validator = validator;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index()
        {
            var values = _announcementService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult GetAnnouncementDetails(int id)
        {
            var values = _announcementService.GetById(id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddAnnouncement()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = values.Name;
            ViewBag.v2 = values.Surname;
            return View();
        }

        [HttpPost]
        //[Route("User/[controller]/[action]")]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            var result = _validator.Validate(announcement);
            if (result.IsValid)
            {
                _announcementService.Add(announcement);
                _notfyService.Success(_sharedLocalizer["announcementAdded"].ToString());
                return LocalRedirect("/User/Announcement/Index/");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notfyService.Error(_sharedLocalizer["announcementError"].ToString());
            }
            return View();
        }
    }
}
