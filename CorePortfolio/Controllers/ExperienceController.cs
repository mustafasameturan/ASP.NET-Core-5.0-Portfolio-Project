using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Business.ValidationRules;
using Business.ValidationRules.FluentValidation;
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
    public class ExperienceController : Controller
    {
        private IExperienceService _experienceService;
        private ExperienceValidator _validator;
        private readonly INotyfService _notyfService;
        private ValidationResult results;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public ExperienceController(IExperienceService experienceService, ExperienceValidator validator, INotyfService notyfService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _experienceService = experienceService;
            _validator = validator;
            _notyfService = notyfService;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index()
        {
            var values = _experienceService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            results = _validator.Validate(experience);

            if (results.IsValid)
            {
                _experienceService.Add(experience);
                //ToastrService.AddToUserQueue(new Business.Services.Toastr("Deneyim Eklendi."));
                _notyfService.Success(_sharedLocalizer["experienceAdded"].ToString());
                //return RedirectToAction("Index");
            }

            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error(_sharedLocalizer["experienceError"].ToString());
            }

            return View();

        }

        public IActionResult DeleteExperience(int id)
        {
            var value = _experienceService.GetById(id);
            _experienceService.Delete(value);

            _notyfService.Success(_sharedLocalizer["experienceDeleted"].ToString());
            return LocalRedirect("/Experience/Index/");
        }

        public IActionResult EditExperience(int id)
        {
            var value = _experienceService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            _experienceService.Update(experience);
            _notyfService.Information(_sharedLocalizer["experienceUpdated"].ToString());
            return LocalRedirect("/Experience/Index/");
        }
    }
}
