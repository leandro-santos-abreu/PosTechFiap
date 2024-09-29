using FluentMigrator.Runner;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostTechFiap.Api;
using Testcontainers.MsSql;
using Testcontainers.RabbitMq;
using MassTransit;
using DotNet.Testcontainers.Builders;
using Consumer;
using System.Diagnostics;

namespace PosTechFiap.Test.IntegrationTests.BaseClasses;

public class CustomWebApplicationFactory : WebApplicationFactory<Startup>, IAsyncDisposable
{
    private readonly MsSqlContainer _container;
    private readonly RabbitMqContainer _rabbitMqContainer;
    private Process? _microserviceProcess;
    private readonly TaskCompletionSource<string> _connectionStringTcs = new TaskCompletionSource<string>();
    private IServiceProvider? _serviceProvider;
    private readonly IConfiguration _configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.Test.json")
            .AddEnvironmentVariables()
            .Build();
    public CustomWebApplicationFactory()
    {
        _container = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithAutoRemove(true)
            .Build();

        _rabbitMqContainer = new RabbitMqBuilder()
        .WithImage("rabbitmq:latest")
        .WithPortBinding(5672, 5672)
        .WithUsername("guest")
        .WithPassword("guest")
        .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(5672))
        .Build();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");

        if (!_configuration.GetValue<bool>("Settings:RunningCI"))
            builder.ConfigureAppConfiguration((context, config) =>
            {
                var connectionString = _connectionStringTcs.Task.Result;
                config.AddInMemoryCollection(new[]
                {
                new KeyValuePair<string, string>("Settings:DbConnectionString", connectionString)
                });
            });


        builder.ConfigureServices(services =>
        {
            services.RemoveMassTransitHostedService();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<CreateContactCommandConsumer>();
                x.AddConsumer<UpdateContactCommandConsumer>();
                x.AddConsumer<DeleteContactCommandConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(_configuration.GetValue<string>("MassTransit:Servidor")!), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint("CreateContact", e =>
                    {
                        e.ConfigureConsumer<CreateContactCommandConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("UpdateContact", e =>
                    {
                        e.ConfigureConsumer<UpdateContactCommandConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("DeleteContact", e =>
                    {
                        e.ConfigureConsumer<DeleteContactCommandConsumer>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();
        });
    }

    public async Task InitializeAsync()
    {
        if (!_configuration.GetValue<bool>("Settings:RunningCI"))
        {
            Console.WriteLine("Starting SQL Server container...");

            await _container.StartAsync();
            if (_container.State != DotNet.Testcontainers.Containers.TestcontainersStates.Running)
                throw new Exception("Failed to start  SQL Server container.");

            _connectionStringTcs.SetResult(_container.GetConnectionString());

            Console.WriteLine("SQL Server container started. Waiting for it to be ready...");

            Console.WriteLine("Starting RabbitMQ Container...");

            await _rabbitMqContainer.StartAsync();

            Console.WriteLine("RabbitMQ container started. Waiting for it to be ready...");

        }

        // Build service provider and apply migrations
        _serviceProvider = Services;

        using var scope = _serviceProvider.CreateScope();


        var migrator = scope.ServiceProvider.GetService<IMigrationRunner>()
            ?? throw new InvalidOperationException("IMigrationRunner service is not registered.");
        migrator.MigrateUp();

        Console.WriteLine("Migrations Applied! SQL Server is ready.");
    }

    public override async ValueTask DisposeAsync()
    {
        if (!_configuration.GetValue<bool>("Settings:RunningCI"))
            return;

        await _container.StopAsync();
        await _container.DisposeAsync();

        await _rabbitMqContainer.StopAsync();
        await _rabbitMqContainer.DisposeAsync();
    }
}