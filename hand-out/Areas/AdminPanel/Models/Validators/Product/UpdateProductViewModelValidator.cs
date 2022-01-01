using FluentValidation;
using hand_out.Areas.AdminPanel.Models.ViewModels.Product;
using static Sidekick.NET.Constant.Validation.Rule.Product;

namespace hand_out.Areas.AdminPanel.Models.Validators.Product
{
    public class UpdateProductViewModelValidator : AbstractValidator<UpdateProductViewModel>
    {
        public UpdateProductViewModelValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .Length(Name.MIN_LENGTH, Name.MAX_LENGTH);

            RuleFor(p => p.Details)
                .MaximumLength(Details.MAX_LENGTH);

            RuleFor(p => p.Address)
                .MaximumLength(Address.MAX_LENGTH);

            RuleFor(p => p.PhotoURL)
                .MaximumLength(PhotoURL.MAX_LENGTH);
        }
    }
}
