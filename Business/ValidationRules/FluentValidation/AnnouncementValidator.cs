using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AnnouncementValidator : AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Duyuru başlığı boş geçilemez!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Duyuru içeriği boş geçilemez!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Duyuruyu yapan kişi adı boş geçilemez!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Duyuruyu yapan kişi soyadı boş geçilemez!");
        }
    }
}
