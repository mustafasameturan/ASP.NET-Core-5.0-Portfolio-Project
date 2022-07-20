using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.ViewComponents.Dashboard
{
    public class DashboardPortfolioSlide : ViewComponent
    {
        private IPortfolioService _portfolioService;
        public DashboardPortfolioSlide(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _portfolioService.GetList();
            return View(values);
        }
    }
}
