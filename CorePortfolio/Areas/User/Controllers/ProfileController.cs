using AspNetCoreHero.ToastNotification.Abstractions;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PortfolioCoreProject.Areas.User.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[action]")]
    [Authorize(Roles = "User")]
    public class ProfileController : Controller
    {
        private readonly UserManager<SystemUser> _userManager;
        private readonly INotyfService _notfyService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public ProfileController(UserManager<SystemUser> userManager, INotyfService notfyService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _userManager = userManager;
            _notfyService = notfyService;
            _sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.ImageUrl = values.ImageUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.ImageUrl = imagename;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            if(p.Password!= null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    _notfyService.Information(_sharedLocalizer["profileUpdated"].ToString());
                    return LocalRedirect("/User/Login/Index/");
                }
                else
                {
                    _notfyService.Error(_sharedLocalizer["profileError"].ToString());
                }
            }
            else
            {
                _notfyService.Warning(_sharedLocalizer["profilePassword"].ToString());
            }

            return View();
        }


    }
}
