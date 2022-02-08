namespace Otal.lmaoo.Web.ViewModelsValidation.User
{
    using FluentValidation;
    using Otal.lmaoo.Web.ViewModels.User;
    using System;

    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(x => x.Forename).NotEmpty().WithMessage("Forename is required");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Password).Must((x, confirmEmailAddress) => x.ConfirmPassword.Equals(confirmEmailAddress, StringComparison.OrdinalIgnoreCase))
                                    .WithMessage("Password and Confirmation Password must match");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password is required");

        }
    }
}