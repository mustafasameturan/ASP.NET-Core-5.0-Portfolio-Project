using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioCoreProject.Areas.User.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı ")]
        [Required(ErrorMessage = "Kullanıcı Adını Giriniz!")]
        public string UserName { get; set; }

        [Display(Name = "Şifre ")]
        [Required(ErrorMessage = "Şifreyi Giriniz!")]
        public string Password { get; set; }
    }
}
