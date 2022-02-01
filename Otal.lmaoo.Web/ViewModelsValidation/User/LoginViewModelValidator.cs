namespace Otal.lmaoo.Web.ViewModelsValidation.User
{
    using FluentValidation;
    using Otal.lmaoo.Web.ViewModels.User;

    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}