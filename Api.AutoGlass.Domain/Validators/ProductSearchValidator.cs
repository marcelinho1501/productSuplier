using Api.AutoGlass.Domain.Models.Request;
using FluentValidation;

namespace Api.AutoGlass.Domain.Validators
{
    public class ProductSearchValidator : AbstractValidator<ProductSearchModel>
    {
        public ProductSearchValidator()
        {
            RuleFor(a => a.PageSize)
                .LessThanOrEqualTo(100)
                .WithMessage(a => "Valor do campo maior do que 100")
                .GreaterThanOrEqualTo(1)
                .WithMessage(a => "Valor do campo menor do que 1");

            RuleFor(a => a.Page)
                .GreaterThanOrEqualTo(1)
                .WithMessage(a => "Valor do campo menor do que 1");
        }
    }
}
