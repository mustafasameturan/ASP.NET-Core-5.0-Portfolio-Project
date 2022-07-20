using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.ViewComponents.ContactInformation
{
    public class ContactInformationList : ViewComponent
    {
        private IContactInformationService _contactInformationService;

        public ContactInformationList(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactInformationService.GetList();
            return View(values);
        }
    }
}
