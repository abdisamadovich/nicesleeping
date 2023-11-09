using FluentValidation;
using Nicesleeping.Services.Dtos.Products;

namespace Nicesleeping.Services.Validators.Dtos.Products;

public class ProductUpdateValidator : AbstractValidator<ProductUpdateDto>
{
    public ProductUpdateValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 50).WithMessage("Productning name uzunligi 1 dan 50 gacha bo'lishi mumkin faqat");
        RuleFor(x => x.Description).Length(1, 1000).WithMessage("Productning description uzunligi 1 dan 1000 gacha bo'lishi mumkin faqat");
        RuleFor(x => x.Textile).MaximumLength(20).WithMessage("Productning textile uzunligi 20 gacha bo'lishi mumkin");
        RuleFor(x => x.Rigidty).MaximumLength(20).WithMessage("Productning rigidty uzunligi 20 gacha bo'lishi mumkin");
    }
}

