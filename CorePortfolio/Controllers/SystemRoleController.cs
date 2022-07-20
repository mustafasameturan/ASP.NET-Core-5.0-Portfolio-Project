using AspNetCoreHero.ToastNotification.Abstractions;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Controllers
{
    public class SystemRoleController : Controller
    {
        private readonly RoleManager<SystemRole> _roleManager;
        private readonly INotyfService _notfyService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public SystemRoleController(RoleManager<SystemRole> roleManager, INotyfService notfyService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _roleManager = roleManager;
            _notfyService = notfyService;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles;
            return View(values);
        }

        public async Task<IActionResult> DeleteSystemRole(string id)
        {
            var value = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(value);
            _notfyService.Success(_sharedLocalizer["roleDeleted"].ToString());
            return LocalRedirect("/SystemRole/Index/");
        }

        [HttpGet]
        public IActionResult AddSystemRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSystemRole(SystemRole role)
        {
            await _roleManager.CreateAsync(role);
            _notfyService.Success(_sharedLocalizer["roleUpdated"].ToString());
            return LocalRedirect("/SystemRole/Index/");
        }
    }
}
