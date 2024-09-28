using Application.Contracts;
using Application.Services;
using Consumer;
using Infrastructure.Context;
using MassTransit;
using Persistence.Contract;
using Persistence.Repositories;

var builder = Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
{
    var configuration = hostContext.Configuration;

    var servidor = configuration.GetSection("MassTransit")["Servidor"] ?? string.Empty;
    var usuario = configuration.GetSection("MassTransit")["Usuario"] ?? string.Empty;
    var senha = configuration.GetSection("MassTransit")["Senha"] ?? string.Empty;

    services.AddMassTransit(x =>
    {
        x.AddConsumer<CreateContactCommandConsumer>();
        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host(new Uri(servidor), "/", h =>
            {
                h.Username(usuario);
                h.Password(senha);
            });

            cfg.ReceiveEndpoint("CreateContact", e =>
            {
                e.ConfigureConsumer<CreateContactCommandConsumer>(context);
            });

            cfg.ConfigureEndpoints(context);
        });
    });

    services.AddScoped<IDbContext, DbContext>();

    services.AddScoped<IContactRepository, ContactRepository>();
    services.AddScoped<IDDDRepository, DDDRepository>();

    services.AddScoped<IContactService, ContactService>();

});



var host = builder.Build();
host.Run();
