using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ExperienceValidator : AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Deneyim Adı boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Deneyim Açıklaması boş geçilemez.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Deneyim Tarihi boş geçilemez.");
            RuleFor(x => x.IconUrl).NotEmpty().WithMessage("Deneyim Ikon URL boş geçilemez.");
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Deneyim Adı 1 karakterden az olamaz");
            RuleFor(x => x.IconUrl).MinimumLength(2).WithMessage("Deneyim Ikon URL 2 karakterden az olamaz");
            RuleFor(x => x.Date).MinimumLength(3).WithMessage("Deneyim Tarihi 3 karakterden az olamaz");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Deneyim Açıklaması 10 karakterden az olamaz.");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Deneyim Açıklaması 200 karakterden fazla olamaz.");
        }
    }
}
