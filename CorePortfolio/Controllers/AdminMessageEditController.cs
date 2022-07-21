using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioCoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageEditController : Controller
    {
        private IUserMessageService _userMessageService;
        private readonly INotyfService _notyfService;

        public AdminMessageEditController(INotyfService notyfService, IUserMessageService userMessageService)
        {
            _notyfService = notyfService;
            _userMessageService = userMessageService;
        }

        public IActionResult Index()
        {
            var values = _userMessageService.GetList();
            return View(values);
        }

        public IActionResult DeleteUserMessage(int id)
        {
            var value = _userMessageService.GetById(id);
            _userMessageService.Delete(value);
            _notyfService.Success("silindi");
            return LocalRedirect("/AdminMessageEdit/Index/");
        }

        public IActionResult DetailMessage(int id)
        {
            var value = _userMessageService.GetById(id);
            return View(value);
        }
    }
}
