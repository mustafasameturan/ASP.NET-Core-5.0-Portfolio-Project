using AspNetCoreHero.ToastNotification.Abstractions;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using PortfolioCoreProject.Areas.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Areas.User.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<SystemUser> _userManager;
        private readonly INotyfService _notyfService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public RegisterController(UserManager<SystemUser> userManager, INotyfService notyfService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _userManager = userManager;
            _notyfService = notyfService;
            _sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {

            if (ModelState.IsValid)
            {
                SystemUser user = new SystemUser()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Mail,
                    UserName = p.UserName,
                    ImageUrl = "user-image.png"
                    
                };
                
                var result = await _userManager.CreateAsync(user, p.Password);


                if (p.Password == p.ConfirmPassword)
                {

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                        _notyfService.Success(_sharedLocalizer["registerSuccess"].ToString());
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        _notyfService.Success(_sharedLocalizer["registerError"].ToString());
                    }
                }
            }
            return View(p);
        }


    }
}
