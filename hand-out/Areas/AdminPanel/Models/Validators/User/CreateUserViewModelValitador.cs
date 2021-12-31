using FluentValidation;
using hand_out.Areas.AdminPanel.Models.ViewModels.User;
using static Sidekick.NET.Constant.Validation.Rule.User;

namespace hand_out.Areas.AdminPanel.Models.Validators.User
{
    public class CreateUserViewModelValitador : AbstractValidator<CreateUserViewModel>
    {
        public CreateUserViewModelValitador()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(Name.MIN_LENGTH, Name.MAX_LENGTH);

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(Email.MAX_LENGTH);

            RuleFor(x => x.Address)
                .MaximumLength(Address.MAX_LENGTH);

            RuleFor(x => x.ProfilePhotoURL)
                .MaximumLength(ProfilePhotoURL.MAX_LENGTH);
        }
    }
}
