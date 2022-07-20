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
    public class UserMessageController : Controller
    {
        private IUserMessageService _userMessageService;

        public UserMessageController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userMessageService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int UserMessageId)
        {
            var result = _userMessageService.GetById(UserMessageId);
            return Ok(result);
        }

        [HttpPost("addusermessage")]
        public IActionResult AddAnnouncement(UserMessage userMessage)
        {
            _userMessageService.Add(userMessage);
            return Ok();
        }

        [HttpDelete("deleteusermessage")]
        public IActionResult DeleteAnnouncement(UserMessage userMessage)
        {
            _userMessageService.Delete(userMessage);
            return Ok();
        }

        [HttpPost("updateusermessage")]
        public IActionResult UpdateAnnouncement(UserMessage userMessage)
        {
            _userMessageService.Update(userMessage);
            return Ok();
        }
    }
}
