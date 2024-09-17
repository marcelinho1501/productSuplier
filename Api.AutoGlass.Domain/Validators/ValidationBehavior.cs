using FluentValidation;
using MediatR;

namespace Api.AutoGlass.Domain.Validators
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validator = validators.FirstOrDefault();
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator != null)
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        throw new Exception(error.ErrorMessage);
                    }
                    return default;
                }
            }

            return await next();
        }
    }
}
