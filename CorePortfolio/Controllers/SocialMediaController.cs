using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using Business.ValidationRules.FluentValidation;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
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
    public class SocialMediaController : Controller
    {
        private ISocialMediaService _socialMediaService;
        private SocialMediaValidator _validator;
        private ValidationResult results;
        private readonly INotyfService _notfyService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public SocialMediaController(ISocialMediaService socialMediaService, SocialMediaValidator validator, INotyfService notfyService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _socialMediaService = socialMediaService;
            _validator = validator;
            _notfyService = notfyService;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index()
        {
            var values = _socialMediaService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            results = _validator.Validate(socialMedia);

            if (results.IsValid)
            {
                _socialMediaService.Add(socialMedia);
                _notfyService.Success(_sharedLocalizer["socialMediaAdded"].ToString());
                //return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notfyService.Error(_sharedLocalizer["socialMediaError"].ToString());
            }

            return View();

        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.GetById(id);
            _socialMediaService.Delete(value);
            _notfyService.Success(_sharedLocalizer["socialMediaDeleted"].ToString());
            return LocalRedirect("/SocialMedia/Index/");
        }

        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            var value = _socialMediaService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaService.Update(socialMedia);
            _notfyService.Information(_sharedLocalizer["socialMediaUpdated"].ToString());
            return LocalRedirect("/SocialMedia/Index/");
        }
    }

}
