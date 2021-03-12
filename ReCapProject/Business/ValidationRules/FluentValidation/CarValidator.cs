using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty().WithMessage("Araba ismi bos birakilamaz!");
            RuleFor(c => c.CarName).MinimumLength(2).WithMessage("Araba ismi minimum 2 karakter olmalıdır!");

            RuleFor(r => r.DailyPrice).NotEmpty().WithMessage("Günlük fiyat bos birakilamaz");
            RuleFor(r => r.DailyPrice).GreaterThan(0).WithMessage("Günlük fiyat 0 dan buyuk olmali");
        }
    }
}
