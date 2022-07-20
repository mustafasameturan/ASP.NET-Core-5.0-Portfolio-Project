using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Proje başlığı boş geçilemez.");
            RuleFor(x => x.Title).MinimumLength(2).WithMessage("Proje başlığı en az 2 karakterden oluşmak zorundadır.");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Proje başlığı en fazla 100 karakterden oluşabilir.");
            RuleFor(x => x.Tool).NotEmpty().WithMessage("Proje aracı boş geçilemez.");
            RuleFor(x => x.Tool).MinimumLength(2).WithMessage("Proje aracı en az 2 karakterden oluşmak zorundadır.");
            RuleFor(x => x.Tool).MaximumLength(70).WithMessage("Proje aracı en fazla 70 karakterden oluşabilir.");
            RuleFor(x => x.ProjectUrl).NotEmpty().WithMessage("Proje aracı boş geçilemez.");
            RuleFor(x => x.ProjectUrl).MinimumLength(2).WithMessage("Proje aracı en az 2 karakterden oluşmak zorundadır.");
            RuleFor(x => x.ToolIconUrl).NotEmpty().WithMessage("Proje araç ikonu boş geçilemez.");
            RuleFor(x => x.ToolIconUrl).MinimumLength(2).WithMessage("Proje araç ikonu en az 2 karakterden oluşmak zorundadır.");
        }
    }
}
