using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Validator;
using FluentValidation;
using Application.Mediator.Command;

namespace Application.Configuration;
public static class MediatorCollectionExtensions
{
    private static MediatRServiceConfiguration AddValidation<TRequest>(this MediatRServiceConfiguration cfg) where TRequest : notnull
    {
        return cfg.AddBehavior<IPipelineBehavior<TRequest, bool>, ValidationBehavior<TRequest>>();
    }

    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            .AddValidation<CreateContactCommand>()
            .AddValidation<UpdateContactCommand>());
    }
}
