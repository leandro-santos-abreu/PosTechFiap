using Application.Mediator.Command;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Validator;
public partial class CreateTenantValidator : AbstractValidator<CreateContactCommand>
{
    public CreateTenantValidator()
    {
        RuleFor(x => x.Telephone).Must(x => x.Length != 9);
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Telephone).NotEmpty();
        RuleFor(x => x.DDD).Must(x => x < 1);
        RuleFor(x => x.Name).Must(x => Regex.IsMatch(x, @"[^a-zA-Z]"));
    }
}