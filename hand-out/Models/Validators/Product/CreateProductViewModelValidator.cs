using FluentValidation;
using hand_out.Models.ViewModels.Product;
using static Sidekick.NET.Constant.Validation.Rule.Product;

namespace hand_out.Models.Validators.Product
{
    public class CreateProductViewModelValidator : AbstractValidator<CreateProductViewModel>
    {
        public CreateProductViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(Name.MIN_LENGTH, Name.MAX_LENGTH);

            RuleFor(p => p.Details)
                .NotNull()
                .NotEmpty()
                .MaximumLength(Details.MAX_LENGTH);

            RuleFor(p => p.Address)
                .NotNull()
                .NotEmpty()
                .MaximumLength(Address.MAX_LENGTH);
        }
    }
}