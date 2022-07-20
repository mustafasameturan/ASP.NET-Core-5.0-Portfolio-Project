using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Areas.User.Models
{
    public class UserEditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [Display(Name = "Şifre ")]
        [Required(ErrorMessage = "Şifreyi Giriniz!")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Required(ErrorMessage = "Şifreyi Tekrar Giriniz!")]
        public string ConfirmPassword { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
