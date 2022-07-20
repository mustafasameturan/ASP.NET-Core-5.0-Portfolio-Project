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
    public class ContactMessageController : Controller
    {
        private IContactMessageService _contactMessageService;
        private readonly INotyfService _notfyService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public ContactMessageController(IContactMessageService contactMessageService, INotyfService notfyService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _contactMessageService = contactMessageService;
            _notfyService = notfyService;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index()
        {
            var values = _contactMessageService.GetList();
            return View(values);
        }

        public IActionResult DeleteContactMessage(int id)
        {
            var value = _contactMessageService.GetById(id);
            _contactMessageService.Delete(value);
            _notfyService.Success(_sharedLocalizer["contactMessageDeleted"].ToString());
            return LocalRedirect("/ContactMessage/Index/");
        }

        public IActionResult ContactMessageDetails(int id)
        {
            var values = _contactMessageService.GetById(id);
            return View(values);
        }
    }
}
