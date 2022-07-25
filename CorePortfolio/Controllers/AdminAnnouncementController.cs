using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
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
    public class AdminAnnouncementController : Controller
    {
        private IAnnouncementService _announcementService;
        private readonly INotyfService _notyfService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public AdminAnnouncementController(IAnnouncementService announcementService, INotyfService notyfService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _announcementService = announcementService;
            _notyfService = notyfService;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index()
        {
            var values = _announcementService.GetList();
            return View(values);
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var value = _announcementService.GetById(id);
            _announcementService.Delete(value);
            _notyfService.Success(_sharedLocalizer["announcementDeleted"].ToString());
            return LocalRedirect("/AdminAnnouncement/Index/");

        }

        public IActionResult AnnouncementDetails(int id)
        {
            var value = _announcementService.GetById(id);
            return View(value);
        }
    }
}
