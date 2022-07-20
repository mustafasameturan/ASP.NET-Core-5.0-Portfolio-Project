using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Controllers
{
    public class ExperienceAjaxController : Controller
    {
        IExperienceService _experienceService;

        public ExperienceAjaxController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(_experienceService.GetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            _experienceService.Add(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetById(int ExperienceID)
        {
            var v = _experienceService.GetById(ExperienceID);
            var value = JsonConvert.SerializeObject(v);
            return Json(value);
        }

        public IActionResult DeleteExperience(int id)
        {
            var v = _experienceService.GetById(id);
            _experienceService.Delete(v);
            return NoContent();
        }
    }
}
