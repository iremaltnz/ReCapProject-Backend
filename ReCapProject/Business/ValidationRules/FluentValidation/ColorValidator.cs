using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator: AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorName).NotEmpty().WithMessage("ColorName alani bos birakilamaz");
            RuleFor(c => c.ColorName).MaximumLength(15).WithMessage("ColorName alani en fazla 15 karakter olabilir");
        }
    }
}
