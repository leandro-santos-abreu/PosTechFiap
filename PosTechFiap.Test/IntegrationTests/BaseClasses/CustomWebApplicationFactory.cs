using FluentMigrator.Runner;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostTechFiap.Api;
using Testcontainers.MsSql;

namespace PosTechFiap.Test.IntegrationTests.BaseClasses;

public class CustomWebApplicationFactory : WebApplicationFactory<Startup>, IAsyncDisposable
{
    private readonly MsSqlContainer _container;
    private readonly TaskCompletionSource<string> _connectionStringTcs = new TaskCompletionSource<string>();
    private IServiceProvider? _serviceProvider;

    public CustomWebApplicationFactory()
    {
        _container = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithAutoRemove(true)
            .Build();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");
        builder.ConfigureAppConfiguration((context, config) =>
        {
            var connectionString = _connectionStringTcs.Task.Result;
            config.AddInMemoryCollection(new[]
            {
            new KeyValuePair<string, string>("Settings:DbConnectionString", connectionString)
            });
        });
    }

    public async Task InitializeAsync()
    {
        await _container.StartAsync();
        _connectionStringTcs.SetResult(_container.GetConnectionString());

        // Build service provider and apply migrations
        _serviceProvider = Services;
        using var scope = _serviceProvider.CreateScope();
        var migrator = scope.ServiceProvider.GetService<IMigrationRunner>()
            ?? throw new InvalidOperationException("IMigrationRunner service is not registered.");
        migrator.MigrateUp();
    }

    public async ValueTask DisposeAsync()
    {
        await _container.StopAsync();
        await _container.DisposeAsync();
    }
}