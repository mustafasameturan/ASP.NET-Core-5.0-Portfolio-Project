using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.ViewComponents.MainPage
{
    public class MainPageList : ViewComponent
    {
        private IMainPageService _mainPageService;

        public MainPageList(IMainPageService mainPageService)
        {
            _mainPageService = mainPageService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _mainPageService.GetList(); 
            return View(values);
        }
    }
}
