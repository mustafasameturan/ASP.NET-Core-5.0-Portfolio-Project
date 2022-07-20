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
    public class SocialMediaController : Controller
    {
        private ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _socialMediaService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int SocialMediaId)
        {
            var result = _socialMediaService.GetById(SocialMediaId);
            return Ok(result);
        }

        [HttpPost("addsocialmedia")]
        public IActionResult AddAnnouncement(SocialMedia socialMedia)
        {
            _socialMediaService.Add(socialMedia);
            return Ok();
        }

        [HttpDelete("deletesocialmedia")]
        public IActionResult DeleteAnnouncement(SocialMedia socialMedia)
        {
            _socialMediaService.Delete(socialMedia);
            return Ok();
        }

        [HttpPost("updatesocialmedia")]
        public IActionResult UpdateAnnouncement(SocialMedia socialMedia)
        {
            _socialMediaService.Update(socialMedia);
            return Ok();
        }
    }
}
