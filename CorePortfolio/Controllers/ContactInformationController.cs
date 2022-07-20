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
    public class ContactInformationController : Controller
    {
        private IContactInformationService _contactInformationService;
        private readonly INotyfService _notfyService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public ContactInformationController(IContactInformationService contactInformationService, INotyfService notfyService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _contactInformationService = contactInformationService;
            _notfyService = notfyService;
            _sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = _contactInformationService.GetById(1);
            return View(value);
        }

        public IActionResult EditContactInformation(ContactInformation contactInformation)
        {
            _contactInformationService.Update(contactInformation);
            _notfyService.Information(_sharedLocalizer["contactInformationUpdated"].ToString());
            return LocalRedirect("/ContactInformation/Index/");
        }
    }
}
