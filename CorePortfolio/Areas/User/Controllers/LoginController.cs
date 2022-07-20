using AspNetCoreHero.ToastNotification.Abstractions;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PortfolioCoreProject.Areas.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[action]")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<SystemUser> _signInManager;
        private readonly INotyfService _notfyService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public LoginController(SignInManager<SystemUser> signInManager, INotyfService notfyService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _signInManager = signInManager;
            _notfyService = notfyService;
            _sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, true, true);
                if (result.Succeeded)
                {
                    if(p.UserName == "admin")
                    {
                        _notfyService.Success(_sharedLocalizer["loginSuccess"].ToString());
                        return LocalRedirect("/Dashboard/Index/");
                    }

                    _notfyService.Success(_sharedLocalizer["loginSuccess"].ToString());
                    return LocalRedirect("/User/UserDashboard/Index/");

                }
                else
                {
                    _notfyService.Error(_sharedLocalizer["loginError"].ToString());

                }
            }
            return View(p);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            //_notfyService.Success("Uygulamadan çıkış yapıldı!");
            return RedirectToAction("Index");
        }
    }
}
