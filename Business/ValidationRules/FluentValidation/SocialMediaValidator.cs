using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class SocialMediaValidator : AbstractValidator<SocialMedia>
    {
        public SocialMediaValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Sosyal Medya Adı boş geçilemez.");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Sosyal Medya URL boş geçilemez.");
            RuleFor(x => x.IconUrl).NotEmpty().WithMessage("Sosyal Medya Ikon URL boş geçilemez.");
            RuleFor(x => x.PlatformIconUrl).NotEmpty().WithMessage("Sosyal Medya Platformu Ikon URL boş geçilemez.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Sosyal Medya Adı en az 3 karakterden oluşmalıdır.");
        }
    }
}
