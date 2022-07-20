using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Yetenek Adı boş geçilemez.");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Yetenek Değeri boş geçilemez.");
            RuleFor(x => x.Title).MinimumLength(1).WithMessage("Yetenek Adı 1 karakterden az olamaz.");
        }
    }
}
