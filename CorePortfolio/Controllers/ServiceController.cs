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
    public class ServiceController : Controller
    {
        private IServiceService _serviceService;
        private ServiceValidator _validator;
        private ValidationResult results;
        private readonly INotyfService _notiftyService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public ServiceController(IServiceService serviceService, ServiceValidator validator, INotyfService notiftyService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _serviceService = serviceService;
            _validator = validator;
            _notiftyService = notiftyService;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index()
        {
            var values = _serviceService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            results = _validator.Validate(service);

            if (results.IsValid)
            {
                _serviceService.Add(service);
                _notiftyService.Success(_sharedLocalizer["serviceAdded"].ToString());
                //return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notiftyService.Error(_sharedLocalizer["serviceError"].ToString());
            }

            return View();
        }

        public IActionResult DeleteService(int id)
        {
            var value = _serviceService.GetById(id);
            _serviceService.Delete(value);
            _notiftyService.Success(_sharedLocalizer["serviceDeleted"].ToString());
            return LocalRedirect("/Service/Index/");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            var value = _serviceService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            _serviceService.Update(service);
            _notiftyService.Information(_sharedLocalizer["serviceUpdated"].ToString());
            return LocalRedirect("/Service/Index/");
        }
    }
}
