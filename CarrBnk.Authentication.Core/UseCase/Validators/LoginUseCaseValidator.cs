using CarrBnk.Authentication.Core.UseCase.Dtos;
using FluentValidation;

namespace CarrBnk.Authentication.Core.UseCase.Validators
{
    public class LoginUseCaseValidator : AbstractValidator<LoginUseCaseRequest>
    {
        public LoginUseCaseValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(4);
        }
    }
}
