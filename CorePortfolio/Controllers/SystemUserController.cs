using AspNetCoreHero.ToastNotification.Abstractions;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using PortfolioCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Controllers
{
    public class SystemUserController : Controller
    {
        private readonly UserManager<SystemUser> _userManager;
        private readonly INotyfService _notfyService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public SystemUserController(UserManager<SystemUser> userManager, INotyfService notfyService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _userManager = userManager;
            _notfyService = notfyService;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index()
        {
            var result = _userManager.Users;
            ViewBag.v1 = _userManager.Users.Count();
            return View(result);
        }

        public async Task<IActionResult> DeleteSystemUser(string id)
        {
            var value = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(value);
            _notfyService.Warning(_sharedLocalizer["userBanned"].ToString());
            return LocalRedirect("/SystemUser/Index/");
        }
    }
}
