using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Areas.User.ViewComponents
{
    public class Notification : ViewComponent
    {
        private IAnnouncementService _announcementService;

        public Notification(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _announcementService.GetList().Take(5).ToList();
            return View(values);
        }
    }
}
