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
    public class AnnouncementController : Controller
    {
        private IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _announcementService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int AnnouncementId)
        {
            var result = _announcementService.GetById(AnnouncementId);
            return Ok(result);
        }

        [HttpPost("addannouncement")]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            _announcementService.Add(announcement);
            return Ok();
        }

        [HttpDelete("deleteannouncement")]
        public IActionResult DeleteAnnouncement(Announcement announcement)
        {
            _announcementService.Delete(announcement);
            return Ok();
        }

        [HttpPost("updateannouncement")]
        public IActionResult UpdateAnnouncement(Announcement announcement)
        {
            _announcementService.Update(announcement);
            return Ok();
        }
    }
}
