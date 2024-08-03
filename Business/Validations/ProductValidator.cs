using Entities;
using FluentValidation;

namespace Business.Validations;

public class ProductValidator : AbstractValidator<Product>
{
    // NOT : Validation'larda business kod yazılmaz !!!!
    public ProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Name).Length(5, 20)
            .WithMessage("Ürün adı uzunluğu 5 karakter ile 20 karakter arasında olmalıdır.");
        RuleFor(p => p.UnitPrice).NotEmpty();
        // unit price 1'den büyük olmalı - ne zaman -> category Id = 1 olanlar icin gecerli bu.
        RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(1).When(p => p.CategoryId == 1);
    }
}