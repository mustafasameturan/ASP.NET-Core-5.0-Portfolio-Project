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
    public class PortfolioController : Controller
    {
        private IPortfolioService _portfolioService;
        private PortfolioValidator _validator;
        private readonly INotyfService _notfyService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public PortfolioController(IPortfolioService portfolioService, PortfolioValidator validator, INotyfService notfyService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _portfolioService = portfolioService;
            _validator = validator;
            _notfyService = notfyService;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index()
        {
            var values = _portfolioService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
           
            ValidationResult results = _validator.Validate(portfolio);

            if (results.IsValid)
            {
                _portfolioService.Add(portfolio);
                _notfyService.Success(_sharedLocalizer["portfolioAdded"].ToString());
                //return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notfyService.Error(_sharedLocalizer["portfolioError"].ToString());
            }

            return View();
           
        }

        public IActionResult DeletePortfolio(int id)
        {
            var value = _portfolioService.GetById(id);
            _portfolioService.Delete(value);
            _notfyService.Success(_sharedLocalizer["portfolioDeleted"].ToString());
            return LocalRedirect("/Portfolio/Index/");
        }

        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            var value = _portfolioService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            _portfolioService.Update(portfolio);
            _notfyService.Information(_sharedLocalizer["portfolioUpdated"].ToString());
            return LocalRedirect("/Portfolio/Index/");
        }
    }
}
