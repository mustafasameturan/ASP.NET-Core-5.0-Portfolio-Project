using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ServiceValidator : AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Servis Adı boş geçilemez.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel URL boş geçilemez.");
            RuleFor(x => x.Title).MinimumLength(1).WithMessage("Servis Adı minimum 1 karakter olmalıdır.");
            RuleFor(x => x.ImageUrl).MinimumLength(1).WithMessage("Görsel URL minimum 1 karakter olmalıdır.");
        }
    }
}
