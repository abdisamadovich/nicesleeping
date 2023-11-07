using FluentValidation;
using Nicesleeping.Services.Dtos.Categories;

namespace Nicesleeping.Services.Validators.Dtos.Categories;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(20).WithMessage("Name must be less than 20 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required!")
            .MinimumLength(5).WithMessage("Description field is required!")
            .MaximumLength(1000).WithMessage("Description must be less than 1000 characters");
    }
}
