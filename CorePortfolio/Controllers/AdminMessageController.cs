using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        private IUserMessageService _userMessageService;
        private readonly INotyfService _notfyService;
        private Context _c;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public AdminMessageController(IUserMessageService userMessageService, Context c, INotyfService notfyService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _userMessageService = userMessageService;
            _c = c;
            _notfyService = notfyService;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult AdminInbox()
        {
            string p;
            p = "admin@mustafasameturan.com";
            var values = _userMessageService.GetListReceiverMessage(p);
            return View(values);
        }

        public IActionResult AdminOutbox()
        {
            string p;
            p = "admin@mustafasameturan.com";
            var values = _userMessageService.GetListSenderMessage(p);
            return View(values);
        }

        public IActionResult AdminMessageDetails(int id)
        {
            var values = _userMessageService.GetById(id);
            return View(values);
        }

        public IActionResult AdminInboxMessageDelete(int id)
        {
            var values = _userMessageService.GetById(id);
            _userMessageService.Delete(values);
            _notfyService.Success(_sharedLocalizer["adminMessageDeleted"].ToString());
            return LocalRedirect("/AdminMessage/AdminInbox/");
        }

        public IActionResult AdminOutboxMessageDelete(int id)
        {
            var values = _userMessageService.GetById(id);
            _userMessageService.Delete(values);
            _notfyService.Success(_sharedLocalizer["adminMessageDeleted"].ToString());
            return LocalRedirect("/AdminMessage/AdminOutbox/");
        }

        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminMessageSend(UserMessage p)
        {
            p.Sender = "admin@mustafasameturan.com";
            p.SenderName = "Admin"; 
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

            var userNameSurname = _c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = userNameSurname;

            if(p.Receiver != null)
            {
                _userMessageService.Add(p);
                _notfyService.Success(_sharedLocalizer["messageSuccess"].ToString());
                return LocalRedirect("/AdminMessage/AdminOutbox/");

            }
            else
            {
                _notfyService.Error(_sharedLocalizer["adminMessageError"].ToString());
                return LocalRedirect("/AdminMessage/AdminOutbox/");
            }
        }
    }
}
