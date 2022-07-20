using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.ViewComponents.Dashboard
{
    public class DashboardNavbarMessageList : ViewComponent
    {
        private IUserMessageService _userMessageService;

        public DashboardNavbarMessageList(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        public IViewComponentResult Invoke()
        {
            string p = "admin@mustafasameturan.com";
            ViewBag.v = _userMessageService.GetList().Count();
            var values = _userMessageService.GetListReceiverMessage(p).OrderByDescending(x => x.UserMessageID).Take(3).ToList();
            return View(values);
        }
    }
}
