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
    public class ContactMessageController : Controller
    {
        private IContactMessageService _contactMessageService;

        public ContactMessageController(IContactMessageService contactMessageService)
        {
            _contactMessageService = contactMessageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _contactMessageService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int ContactMessageId)
        {
            var result = _contactMessageService.GetById(ContactMessageId);
            return Ok(result);
        }

        [HttpPost("addcontactmessage")]
        public IActionResult AddAnnouncement(ContactMessage contactMessage)
        {
            _contactMessageService.Add(contactMessage);
            return Ok();
        }

        [HttpDelete("deletecontactmessage")]
        public IActionResult DeleteAnnouncement(ContactMessage contactMessage)
        {
            _contactMessageService.Delete(contactMessage);
            return Ok();
        }

        [HttpPost("updatecontactmessage")]
        public IActionResult UpdateAnnouncement(ContactMessage contactMessage)
        {
            _contactMessageService.Update(contactMessage);
            return Ok();
        }
    }
}