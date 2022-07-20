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
    public class AboutController : Controller
    {
        private IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _aboutService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByAboutId(int aboutId)
        {
            var result = _aboutService.GetById(aboutId);
            return Ok(result);
        }

        [HttpDelete("deleteabout")]
        public IActionResult DeleteAbout(About about)
        {
             _aboutService.Delete(about);
            return Ok();
        }

        [HttpPost("updateabout")]
        public IActionResult UpdateAbout(About about)
        {
            _aboutService.Update(about);
            return Ok();
        }
    }
}
