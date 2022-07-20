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
    public class SkillController : Controller
    {
        private ISkillService _skillService;
        private SkillValidator _validator;
        private ValidationResult results;
        private readonly INotyfService _notifyService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public SkillController(ISkillService skillService, SkillValidator validator, INotyfService notifyService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _skillService = skillService;
            _validator = validator;
            _notifyService = notifyService;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index()
        {
            var values = _skillService.GetList();
            return View(values);
        }
        
        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            results = _validator.Validate(skill);

            if (results.IsValid)
            {
                _skillService.Add(skill);
                _notifyService.Success(_sharedLocalizer["skillAdded"].ToString());
                //return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notifyService.Success(_sharedLocalizer["skillError"].ToString());
            }

            return View();
        }
        
        public IActionResult DeleteSkill(int id)
        {
            var value = _skillService.GetById(id);
            _skillService.Delete(value);
            _notifyService.Success(_sharedLocalizer["skillDeleted"].ToString());
            return LocalRedirect("/Skill/Index/");
        }

        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            var value = _skillService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            _skillService.Update(skill);
            _notifyService.Information(_sharedLocalizer["skillUpdated"].ToString());
            return LocalRedirect("/Skill/Index/");
        }
    }
}
