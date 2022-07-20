using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PorftolioCoreProject_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : Controller
    {
        private IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _experienceService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int ExperienceId)
        {
            var result = _experienceService.GetById(ExperienceId);
            return Ok(result);
        }

        [HttpPost("addexperience")]
        public IActionResult AddAnnouncement(Experience experience)
        {
            _experienceService.Add(experience);
            return Ok();
        }

        [HttpDelete("deleteexperience")]
        public IActionResult DeleteAnnouncement(Experience experience)
        {
            _experienceService.Delete(experience);
            return Ok();
        }

        [HttpPost("updateexperience")]
        public IActionResult UpdateAnnouncement(Experience experience)
        {
            _experienceService.Update(experience);
            return Ok();
        }
    }
}
