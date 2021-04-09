using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class AuthValidator :  AbstractValidator<UserForRegisterDto>
    {
        public AuthValidator()
        {
            RuleFor(u => u.Password).MinimumLength(8).WithMessage("Şifre en az 8 karakterden oluşmalıdır.!");
        }
    }
}
