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
    public class SkillController : Controller
    {
        private ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _skillService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int SkillId)
        {
            var result = _skillService.GetById(SkillId);
            return Ok(result);
        }

        [HttpPost("addskill")]
        public IActionResult AddAnnouncement(Skill skill)
        {
            _skillService.Add(skill);
            return Ok();
        }

        [HttpDelete("deleteskill")]
        public IActionResult DeleteAnnouncement(Skill skill)
        {
            _skillService.Delete(skill);
            return Ok();
        }

        [HttpPost("updateskill")]
        public IActionResult UpdateAnnouncement(Skill skill)
        {
            _skillService.Update(skill);
            return Ok();
        }
    }
}
