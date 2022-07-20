using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.ViewComponents.Experience
{
    public class ExperienceList : ViewComponent
    {
        private IExperienceService _experienceService;

        public ExperienceList(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _experienceService.GetList();
            return View(values);
        }
    }
}
