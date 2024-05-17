using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Application.Validator;
public class ValidationBehavior<TRequest>(IValidator<TRequest> validator) : IPipelineBehavior<TRequest, ValidationResult> where TRequest : notnull 
{
    private readonly IValidator<TRequest> validator = validator ?? throw new ArgumentNullException(nameof(validator));

    public async Task<ValidationResult> Handle(TRequest request, RequestHandlerDelegate<ValidationResult> next, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult;
        }

        return await next();
    }
}