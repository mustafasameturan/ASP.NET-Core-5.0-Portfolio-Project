using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/UserMessage")]
    [Authorize(Roles = "User")]
    public class UserMessageController : Controller
    {
        private IUserMessageService _userMessageService;
        private readonly UserManager<SystemUser> _userManager;
        private Context _c;
        private readonly INotyfService _notfyService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public UserMessageController(IUserMessageService userMessageService, UserManager<SystemUser> userManager, Context c, INotyfService notfyService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _userMessageService = userMessageService;
            _userManager = userManager;
            _c = c;
            _notfyService = notfyService;
            _sharedLocalizer = sharedLocalizer;
        }

        [Route("")]
        [Route("Inbox")]
        public async Task<IActionResult> Inbox(String p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            p = value.Email;
            var messageList = _userMessageService.GetListReceiverMessage(p);
            return View(messageList);
        }

        [Route("")]
        [Route("Outbox")]
        public async Task<IActionResult> Outbox(String p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            p = value.Email;
            var messageList = _userMessageService.GetListSenderMessage(p);
            return View(messageList);
        }

        [Route("GetReceiverMessageDetails/{id}")]
        public IActionResult GetReceiverMessageDetails(int id)
        {
            var values = _userMessageService.GetById(id);
            return View(values);
        }

        [Route("GetSenderMessageDetails/{id}")]
        public IActionResult GetSenderMessageDetails(int id)
        {
            var values = _userMessageService.GetById(id);
            return View(values);
        }

        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(UserMessage p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = value.Email;
            string name = value.Name + " " + value.Surname;

            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.SenderName = name;
            p.Sender = mail;
            var userNameSurname = _c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = userNameSurname;

            if (p.Receiver != null)
            {
                _userMessageService.Add(p);
                _notfyService.Success(_sharedLocalizer["userMessageSend"].ToString());
                return LocalRedirect("/User/UserMessage/Outbox/");
            }
            else
            {
                _notfyService.Error(_sharedLocalizer["userMessageError"].ToString());
                return LocalRedirect("/User/UserMessage/Outbox/");
            }


        }
    }
}
