using FluentValidation;
using MediatR;

namespace Application.Validator;
public class ValidationBehavior<TRequest>(IValidator<TRequest> validator) : IPipelineBehavior<TRequest, bool> where TRequest : notnull 
{
    private readonly IValidator<TRequest> validator = validator ?? throw new ArgumentNullException(nameof(validator));

    public async Task<bool> Handle(TRequest request, RequestHandlerDelegate<bool> next, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.IsValid;
        }

        return await next();
    }
}