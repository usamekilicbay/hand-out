using FluentValidation;
using hand_out.Areas.Admin.Models.ViewModels.User;
using static Sidekick.NET.Constant.Validation.Rule.User;

namespace hand_out.Areas.Admin.Models.Validators.User
{
    public class UpdateUserViewModelValidator : AbstractValidator<UpdateUserViewModel>
    {
        public UpdateUserViewModelValidator()
        {
            RuleFor(x => x.UserName)
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
