using FluentValidation;
using hand_out.Models.ViewModels.User;
using Sidekick.NET.Constant.Validation;
using static Sidekick.NET.Constant.Validation.Rule.User;

namespace hand_out.Models.Validators.User
{
    public class SingUpUserViewModelValidator : AbstractValidator<SignUpUserViewModel>
    {
        public SingUpUserViewModelValidator()
        {
            RuleFor(u => u.UserName)
                .NotNull()
                .NotEmpty()
                .Length(Name.MIN_LENGTH, Name.MAX_LENGTH);

            RuleFor(u => u.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(Email.MAX_LENGTH);
        }
    }
}
