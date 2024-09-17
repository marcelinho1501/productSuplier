﻿using Api.AutoGlass.Domain.Command;
using FluentValidation;

namespace Api.AutoGlass.Domain.Validators
{
    public class UpdateRequestValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateRequestValidator()
        {
            RuleFor(x => x.DateManufacturing)
            .LessThan(x => x.DateValidate)
            .When(x => x.DateManufacturing.HasValue && x.DateValidate.HasValue)
            .WithMessage("A data de fabricação deve ser menor que a data de validade.");
        }
    }
}