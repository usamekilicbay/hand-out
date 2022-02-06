using FluentValidation;
using hand_out.Areas.Admin.Models.ViewModels.Category;
using static Sidekick.NET.Constant.Validation.Rule.Category;

namespace hand_out.Areas.Admin.Models.Validators.Category
{
    public class UpdateCategoryViewModelValidator : AbstractValidator<UpdateCategoryViewModel>
    {
        public UpdateCategoryViewModelValidator()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .NotEmpty()
                .Length(Name.MIN_LENGTH, Name.MAX_LENGTH);
        }
    }
}
